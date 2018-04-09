--SELECTS--
--однотабличная выборка
--1.Вывести ФИО персонала, упорядочив в алфавитном порядке по фамилии и в обратном порядке по имени
SELECT LAST_NAME, FIRST_NAME
FROM AUTO_PERSONNEL
ORDER BY LAST_NAME, FIRST_NAME;

--2.Посчитать количество автомобилей, у которых первая буква номера «р»
SELECT COUNT(*) AS COUNT FROM AUTO WHERE NUM LIKE 'p%';

--выборка с подзапросами
--1.Вывести номера автомобилей водителя с заданной фамилией
SELECT NUM FROM AUTO WHERE PERSONNEL_ID = (SELECT ID FROM AUTO_PERSONNEL WHERE LAST_NAME = 'Петров');

--2.Вывести наименования маршрутов, на которых есть не вернувшиеся автомобили
SELECT NAME FROM ROUTES WHERE ID = (SELECT ROUTE_ID FROM JORNAL WHERE TIME_IN IS NULL);

--соединение таблиц (join)
--1.Вывести время отправки из журнала оператора и наименования маршрутов, включая маршруты, по которым рейсов не было
SELECT ROUTES.NAME AS NAME, JORNAL.TIME_OUT AS TIME_OUT
FROM ROUTES
LEFT OUTER JOIN JORNAL ON ROUTES.ID = JORNAL.ROUTE_ID;

--2.Вывести времена отправки/прибытия из журнала оператора, наименования маршрутов поездок, включая маршруты,
--по которым не было рейсов, и номера автомобилей, включая автомобили которые не участвовали в рейсах.
SELECT JORNAL.TIME_OUT AS TIME_OUT, JORNAL.TIME_IN AS TIME_IN, ROUTES.NAME AS NAME, AUTO.NUM AS NUM
FROM JORNAL
RIGHT OUTER JOIN ROUTES ON ROUTES.ID = JORNAL.ROUTE_ID
RIGHT OUTER JOIN AUTO ON AUTO.ID = JORNAL.AUTO_ID;

--для реализации проекта
--1.Вывести самое короткое время проезда по заданному наименованием маршруту и номер автомобиля, который поставил рекорд.
SELECT TIME, NUM FROM (SELECT TIME_IN - TIME_OUT AS TIME, NUM AS NUM FROM (SELECT JORNAL.TIME_OUT AS TIME_OUT, JORNAL.TIME_IN AS TIME_IN, ROUTES.NAME AS NAME, AUTO.NUM AS NUM
FROM JORNAL
RIGHT OUTER JOIN ROUTES ON ROUTES.ID = JORNAL.ROUTE_ID
RIGHT OUTER JOIN AUTO ON AUTO.ID = JORNAL.AUTO_ID) WHERE NAME = 'наб. Октябрьская')
WHERE TIME = (SELECT MIN(TIME) FROM (SELECT TIME_IN - TIME_OUT AS TIME, NUM AS NUM FROM (SELECT JORNAL.TIME_OUT AS TIME_OUT, JORNAL.TIME_IN AS TIME_IN, ROUTES.NAME AS NAME, AUTO.NUM AS NUM
FROM JORNAL
RIGHT OUTER JOIN ROUTES ON ROUTES.ID = JORNAL.ROUTE_ID
RIGHT OUTER JOIN AUTO ON AUTO.ID = JORNAL.AUTO_ID) WHERE NAME = 'наб. Октябрьская'));

--2.Количество автомобилей находящихся в рейсе по заданному наименованием маршруту
SELECT COUNT(AUTO_ID) AS COUNT_AUTO FROM JORNAL WHERE TIME_IN IS NULL AND ROUTE_ID = (SELECT ID FROM ROUTES WHERE NAME = 'ул. Верхняя');

--Вставка данных
--однотабличная вставка
--1.Добавить водителю с заданной фамилией два автомобиля
INSERT INTO AUTO
(NUM, COLOR, MARK, PERSONNEL_ID)
VALUES
('p989ce', 'зеленый', 'LADA', (SELECT ID FROM AUTO_PERSONNEL WHERE LAST_NAME = 'Петров'));
--
INSERT INTO AUTO
(NUM, COLOR, MARK, PERSONNEL_ID)
VALUES
('p989ce', 'красный', 'NISSAN', (SELECT ID FROM AUTO_PERSONNEL WHERE LAST_NAME = 'Петров'));
--2.Отправить водителя с заданной фамилией на желтой машине в рейс по маршруту с известным id.
INSERT INTO JORNAL
(TIME_OUT, TIME_IN, AUTO_ID, ROUTE_ID)
VALUES
('21.03.18 13:51:28,264000000', NULL ,(SELECT ID FROM AUTO WHERE COLOR = 'желтый' AND PERSONNEL_ID =
(SELECT ID FROM AUTO_PERSONNEL WHERE lAST_NAME = 'Писмецов')), 66);

--многотабличная вставка в рамках транзакции
--1.Добавить запись в журнал, в случае, если автомобилей в данном рейсе больше 2-ух, транзакцию откатить
DECLARE
V_COUNT NUMBER;
BEGIN
    INSERT INTO JORNAL VALUES ('109', '27.03.18 20:51:28,264000000', NULL, '52', '61');
    SELECT COUNT(ID) INTO V_COUNT FROM JORNAL WHERE ROUTE_ID = '61';
    IF (V_COUNT > 2)
      THEN ROLLBACK;
    END IF;
    EXCEPTION WHEN OTHERS
    THEN
      ROLLBACK;
      RAISE;
    END;

--Удаление данных
--удаление по фильтру и удаление из связанных таблиц
--1.Удалить маршрут и все, связанные с ним, записи в журнале
ALTER TRIGGER ROUTES_ID_TRG DISABLE; --отключаем тригер
ALTER TRIGGER JORNAL_ID_TRG DISABLE;

DECLARE
V_ID NUMBER;
BEGIN
  SELECT ID INTO V_ID FROM ROUTES WHERE NAME = 'ул. Верхняя';
  DELETE FROM ROUTES WHERE ID = V_ID;
  DELETE FROM JORNAL WHERE ROUTE_ID = V_ID;
END;

ALTER TRIGGER ROUTES_ID_TRG ENABLE; --включаем тригер
ALTER TRIGGER JORNAL_ID_TRG ENABLE;

--2.Удалить персонал, не имеющий автомобилей
ALTER TRIGGER AUTO_PERSONNEL_ID_TRG DISABLE; --отключаем тригер

DELETE FROM AUTO_PERSONNEL
WHERE AUTO_PERSONNEL.ID NOT IN
      (
        SELECT PERSONNEL_ID
        FROM AUTO
      );

ALTER TRIGGER AUTO_PERSONNEL_ID_TRG ENABLE; --включаем тригер

--удаление в рамках транзакции
--1.Удалить в рамках транзакции заданного водителя и его автомобили
ALTER TRIGGER AUTO_PERSONNEL_ID_TRG DISABLE; --отключаем тригер
ALTER TRIGGER AUTO_ID_TRG DISABLE;

SET TRANSACTION NAME 'tr_0';
BEGIN
  DECLARE
A_ID NUMBER;
BEGIN
  SELECT ID INTO A_ID FROM AUTO_PERSONNEL WHERE LAST_NAME = 'Игнатьев';
  DELETE FROM AUTO WHERE PERSONNEL_ID = A_ID;
  DELETE FROM AUTO_PERSONNEL WHERE ID = A_ID;
END;
  COMMIT;
  EXCEPTION WHEN OTHERS
  THEN
    ROLLBACK;
    RAISE;
END;

ALTER TRIGGER AUTO_PERSONNEL_ID_TRG ENABLE; --включаем тригер
ALTER TRIGGER AUTO_ID_TRG ENABLE;

--2.то же, что и п1, но транзакцию откатить
ALTER TRIGGER AUTO_PERSONNEL_ID_TRG DISABLE; --отключаем тригер
ALTER TRIGGER AUTO_ID_TRG DISABLE;

SET TRANSACTION NAME 'tr_1';
BEGIN
  DECLARE
A_ID NUMBER;
BEGIN
  SELECT ID INTO A_ID FROM AUTO_PERSONNEL WHERE LAST_NAME = 'Игнатьев';
  DELETE FROM AUTO WHERE PERSONNEL_ID = A_ID;
  DELETE FROM AUTO_PERSONNEL WHERE ID = A_ID;
END;
  ROLLBACK;
  EXCEPTION WHEN OTHERS
  THEN
    ROLLBACK;
    RAISE;
END;

ALTER TRIGGER AUTO_PERSONNEL_ID_TRG ENABLE; --включаем тригер
ALTER TRIGGER AUTO_ID_TRG ENABLE;

--Модификация данных
--1.Изменить время прибытия у заданной строки журнала оператора
UPDATE JORNAL
     SET TIME_IN = '17.03.18 14:27:28,946000000'
 WHERE ID = 107;

--2.Изменить маршрут, по которому следует автомобиль с заданным номером
UPDATE JORNAL
      SET ROUTE_ID = 61
WHERE AUTO_ID = (SELECT ID FROM AUTO WHERE NUM = 'x576xe');

--модификация в рамках транзакции
--1.В рамках транзакции поменять заданный маршрут всех поездок в журнале на другой и удалить заданный маршрут.
SET TRANSACTION NAME 'tr_2';
BEGIN
  UPDATE JORNAL
  SET ROUTE_ID = 66
  WHERE ROUTE_ID = 67;
  DELETE FROM ROUTES
  WHERE ID = 67;
  COMMIT;
END;

--2.то же, что и п1, но транзакцию откатить
SET TRANSACTION NAME 'tr_3';
BEGIN
    UPDATE JORNAL
  SET ROUTE_ID = 66
  WHERE ROUTE_ID = 67;
  DELETE FROM ROUTES
  WHERE ID = 67;
  ROLLBACK ;
END;
