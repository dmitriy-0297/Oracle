using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Windows.Forms;

namespace CourseBD
{
    public partial class DispForm : Form
    {
        public DispForm()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
            ora.Open();
            OracleCommand com = new OracleCommand("selectJornal", ora);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add("reg", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapt = new OracleDataAdapter();
            adapt.SelectCommand = com;
            DataTable table = new DataTable();
            adapt.Fill(table);
            dataGridView1.DataSource = table;
            ora.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
            ora.Open();
            Conn c = new Conn();
            c.Show();
            ora.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
            ora.Open();
            OracleCommand com = new OracleCommand("selectRoute", ora);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add("reg", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapt = new OracleDataAdapter();
            adapt.SelectCommand = com;
            DataTable table = new DataTable();
            adapt.Fill(table);
            dataGridView2.DataSource = table;
            ora.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (addRoute.Text == "")
            {
                ErrorInputLable er = new ErrorInputLable();
                er.Show();
            }
            else
            {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                OracleCommand com = new OracleCommand("addRoute", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("nameRoute", OracleType.Char, 50).Value = addRoute.Text;
                com.ExecuteNonQuery();
                AddForm a = new AddForm();
                a.Show();
                ora.Close();
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (delRoute.Text == "")
            {
                ErrorInputLable er = new ErrorInputLable();
                er.Show();
            }
            else
            {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                OracleCommand com = new OracleCommand("delRoute", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("nameRoute", OracleType.Char, 50).Value = delRoute.Text;
                com.ExecuteNonQuery();
                DelWokerForm d = new DelWokerForm();
                d.Show();
                ora.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
            ora.Open();
            OracleCommand com = new OracleCommand("selectAuto", ora);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add("reg", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapt = new OracleDataAdapter();
            adapt.SelectCommand = com;
            DataTable table = new DataTable();
            adapt.Fill(table);
            dataGridView3.DataSource = table;
            ora.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (delAutoNum.Text == "")
            {
                ErrorInputLable er = new ErrorInputLable();
                er.Show();
            }
            else {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                OracleCommand com = new OracleCommand("delAuto", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("numAuto", OracleType.Char, 20).Value = delAutoNum.Text;
                com.ExecuteNonQuery();
                DelWokerForm d = new DelWokerForm();
                d.Show();
                ora.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (txtNum.Text == "" || txtCol.Text == "" || txtMark.Text == "" || txtPer.Text == "")
            {
                ErrorInputLable er = new ErrorInputLable();
                er.Show();
            }
            else {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                OracleCommand com = new OracleCommand("addAuto", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("numAuto", OracleType.Char, 20).Value = txtNum.Text;
                com.Parameters.Add("colAuto", OracleType.Char, 20).Value = txtCol.Text;
                com.Parameters.Add("markAuto", OracleType.Char, 20).Value = txtMark.Text;
                com.Parameters.Add("perAuto", OracleType.Char, 20).Value = txtPer.Text;
                com.ExecuteNonQuery();
                AddForm a = new AddForm();
                a.Show();
                ora.Close();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
            ora.Open();
            OracleCommand com = new OracleCommand("selectAutoPersonel", ora);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add("reg", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapt = new OracleDataAdapter();
            adapt.SelectCommand = com;
            DataTable table = new DataTable();
            adapt.Fill(table);
            dataGridView4.DataSource = table;
            ora.Close();
        }

        private void UpColor_Click(object sender, EventArgs e)
        {
            if (UpNumEX.Text == "" || textCol.Text == "")
            {
                ErrorInputLable er = new ErrorInputLable();
                er.Show();
            }
            else {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                OracleCommand com = new OracleCommand("updateAutoCol", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("numAuto", OracleType.Char, 20).Value = UpNumEX.Text;
                com.Parameters.Add("colorAuto", OracleType.Char, 20).Value = textCol.Text;
                com.ExecuteNonQuery();
                updateForm u = new updateForm();
                u.Show();
                ora.Close();
            }
        }

        private void UpNum_Click(object sender, EventArgs e)
        {
            if (UpNumEX.Text == "" || textNum.Text == "")
            {
                ErrorInputLable er = new ErrorInputLable();
                er.Show();
            }
            else
            {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                OracleCommand com = new OracleCommand("updateAutoNum", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("numAuto1", OracleType.Char, 20).Value = UpNumEX.Text;
                com.Parameters.Add("numAuto2", OracleType.Char, 20).Value = textNum.Text;
                com.ExecuteNonQuery();
                updateForm u = new updateForm();
                u.Show();
                ora.Close();
            }
        }

        private void UpPer_Click(object sender, EventArgs e)
        {
            if (UpNumEX.Text == "" || textLastName.Text == "")
            {
                ErrorInputLable er = new ErrorInputLable();
                er.Show();
            }
            else {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                OracleCommand com = new OracleCommand("updateLastNameAuto", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("numAuto", OracleType.Char, 20).Value = UpNumEX.Text;
                com.Parameters.Add("lastName", OracleType.Char, 20).Value = textLastName.Text;
                com.ExecuteNonQuery();
                updateForm u = new updateForm();
                u.Show();
                ora.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (txtDelID.Text == "")
            {
                ErrorInputLable er = new ErrorInputLable();
                er.Show();
            }
            else
            {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                OracleCommand com = new OracleCommand("dellPost", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("ID_J", OracleType.Number).Value = txtDelID.Text;
                com.ExecuteNonQuery();
                DelWokerForm d = new DelWokerForm();
                d.Show();
                ora.Close();
            }
        }

        private void txtUpdateID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (txtTOut.Text == "" || txtTIn.Text == "" || txtNAuto.Text == "" || txtNR.Text == "")
            {
                ErrorInputLable er = new ErrorInputLable();
                er.Show();
            }
            else
            {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                try
                {
                    OracleCommand com = new OracleCommand("addPostJ", ora);
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.Add("T_OUT", OracleType.Char, 20).Value = txtTOut.Text;
                    com.Parameters.Add("T_IN", OracleType.Char, 20).Value = txtTIn.Text;
                    com.Parameters.Add("A_NUM", OracleType.Char, 6).Value = txtNAuto.Text;
                    com.Parameters.Add("R_NAME", OracleType.Char, 50).Value = txtNR.Text;
                    com.ExecuteNonQuery();
                    AddForm a = new AddForm();
                    a.Show();
                }
                catch (Exception ex)
                {
                    ErrorInsertPartJournal er = new ErrorInsertPartJournal();
                    er.Show();
                }
                ora.Close();
            }
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (txtUpdateID.Text == "" || txtUpdateT_Out.Text == "")
            {
                ErrorInputLable er = new ErrorInputLable();
                er.Show();
            }
            else
            {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                try
                {
                    OracleCommand com = new OracleCommand("updateJornalOutT", ora);
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.Add("upId", OracleType.Number).Value = txtUpdateID.Text;
                    com.Parameters.Add("T_OUT", OracleType.Char, 20).Value = txtUpdateT_Out.Text;
                    com.ExecuteNonQuery();
                    updateForm u = new updateForm();
                    u.Show();
                }
                catch (Exception ex)
                {
                    ErrorTime er = new ErrorTime();
                    er.Show();
                    txtUpdateT_Out.Text = "";
                }
                ora.Close();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (txtUpdateID.Text == "" || txtUpdateT_In.Text == "")
            {
                ErrorInputLable er = new ErrorInputLable();
                er.Show();
            }
            else
            {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                try
                {
                    OracleCommand com = new OracleCommand("updateJornalInT", ora);
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.Add("upId", OracleType.Number).Value = txtUpdateID.Text;
                    com.Parameters.Add("T_IN", OracleType.Char, 20).Value = txtUpdateT_In.Text;
                    com.ExecuteNonQuery();
                    updateForm u = new updateForm();
                    u.Show();
                }
                catch (Exception ex)
                {
                    ErrorTime er = new ErrorTime();
                    er.Show();
                    txtUpdateT_In.Text = "";
                }
                ora.Close();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (txtUpdateID.Text == "" || txtUpdateNumAuto.Text == "")
            {
                ErrorInputLable er = new ErrorInputLable();
                er.Show();
            }
            else
            {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                OracleCommand com = new OracleCommand("updateAutoInJ", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("upId", OracleType.Number).Value = txtUpdateID.Text;
                com.Parameters.Add("numAuto", OracleType.Char, 20).Value = txtUpdateNumAuto.Text;
                com.ExecuteNonQuery();
                updateForm u = new updateForm();
                u.Show();
                ora.Close();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (txtUpdateID.Text == "" || txtUpdateNameRole.Text == "")
            {
                ErrorInputLable er = new ErrorInputLable();
                er.Show();
            }
            else
            {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                OracleCommand com = new OracleCommand("updateNameRouteJornal", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("upId", OracleType.Number).Value = txtUpdateID.Text;
                com.Parameters.Add("NameR", OracleType.Char, 60).Value = txtUpdateNameRole.Text;
                com.ExecuteNonQuery();
                updateForm u = new updateForm();
                u.Show();
                ora.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (txtNameDop1.Text == "")
            {
                ErrorInputLable er = new ErrorInputLable();
                er.Show();
            }
            else {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                OracleCommand com = new OracleCommand("shortestTime", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("NAME_ROUTE", OracleType.Char, 50).Value = txtNameDop1.Text;
                com.Parameters.Add("TIME_SHORTEST", OracleType.IntervalDayToSecond).Direction = ParameterDirection.Output;
                com.Parameters.Add("NUMBER_AUTO", OracleType.Char, 20).Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();
                txtTimeDop1.Text = com.Parameters["TIME_SHORTEST"].Value.ToString();
                txtNumAutoDop1.Text = com.Parameters["NUMBER_AUTO"].Value.ToString();
                ora.Close();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (NameRouteDop2.Text == "")
            {
                ErrorInputLable er = new ErrorInputLable();
                er.Show();
            }
            else {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                OracleCommand com = new OracleCommand("countAutoOnTheRoute", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("NAME_R", OracleType.Char, 50).Value = NameRouteDop2.Text;
                com.Parameters.Add("COUNT_AUTO", OracleType.Number).Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();
                countAutoDop2.Text = com.Parameters["COUNT_AUTO"].Value.ToString();
                ora.Close();
            }
        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void txtTOut_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
