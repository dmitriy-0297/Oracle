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
using System.Text.RegularExpressions;

namespace CourseBD
{
    public partial class DispForm : Form
    {
        public string time_out;
        public string time_in;
        public string auto_id;
        public string route_id;
 
        public DispForm()
        {
            InitializeComponent();
            OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
            ora.Open();
            OracleCommand com_v1 = new OracleCommand("selectJornal", ora);
            com_v1.CommandType = System.Data.CommandType.StoredProcedure;
            com_v1.Parameters.Add("reg", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapt_v1 = new OracleDataAdapter();
            adapt_v1.SelectCommand = com_v1;
            DataTable table_v1 = new DataTable();
            adapt_v1.Fill(table_v1);
            dataGridView1.DataSource = table_v1;
            ora.Close();
            ora.Open();
            OracleCommand com_v2 = new OracleCommand("selectRoute", ora);
            com_v2.CommandType = System.Data.CommandType.StoredProcedure;
            com_v2.Parameters.Add("reg", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapt_v2 = new OracleDataAdapter();
            adapt_v2.SelectCommand = com_v2;
            DataTable table_v2 = new DataTable();
            adapt_v2.Fill(table_v2);
            dataGridView2.DataSource = table_v2;
            ora.Close();
            ora.Open();
            OracleCommand com_v3 = new OracleCommand("selectAuto", ora);
            com_v3.CommandType = System.Data.CommandType.StoredProcedure;
            com_v3.Parameters.Add("reg", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapt_v3 = new OracleDataAdapter();
            adapt_v3.SelectCommand = com_v3;
            DataTable table_v3 = new DataTable();
            adapt_v3.Fill(table_v3);
            dataGridView3.DataSource = table_v3;
            ora.Close();
            ora.Open();
            OracleCommand com_v4 = new OracleCommand("selectAutoPersonel", ora);
            com_v4.CommandType = System.Data.CommandType.StoredProcedure;
            com_v4.Parameters.Add("reg", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapt_v4 = new OracleDataAdapter();
            adapt_v4.SelectCommand = com_v4;
            DataTable table_v4 = new DataTable();
            adapt_v4.Fill(table_v4);
            dataGridView4.DataSource = table_v4;
            
            ora.Close();
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
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                OracleCommand com = new OracleCommand("delRoute", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("nameRoute", OracleType.Char, 50).Value = comboBox1.Text;
                com.ExecuteNonQuery();
                DelWokerForm d = new DelWokerForm();
                d.Show();
                ora.Close();
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
            else
            {
                Regex regex = new Regex(@"[a-z]{1}[0-9]{3}[a-z]{2}");
                Match match = regex.Match(txtNum.Text.ToString());
                if(match.Success)
                {
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
                else
                {
                    ErrorInputLable er = new ErrorInputLable();
                    er.Show();
                }
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

        }

        private void txtUpdateID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                try
                {
                    OracleCommand com = new OracleCommand("addPostJ", ora);
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    string dateOut = (dateTimePicker3.Value.Date + dateTimePicker4.Value.TimeOfDay).ToString("yyyy-MM-dd HH:mm:ss");
                    com.Parameters.Add("T_OUT", OracleType.Char, 20).Value = dateOut;
                    string dateIn = (dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay).ToString("yyyy-MM-dd HH:mm:ss");
                    com.Parameters.Add("T_IN", OracleType.Char, 20).Value = dateIn;
                    com.Parameters.Add("A_NUM", OracleType.Char, 6).Value = comboBoxNumAuto1.Text;
                    com.Parameters.Add("R_NAME", OracleType.Char, 50).Value = comboBox1NameRoute.Text;
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

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
        }

        private void button13_Click(object sender, EventArgs e)
        {
        }

        private void button14_Click(object sender, EventArgs e)
        {
        }

        private void button15_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                OracleCommand com = new OracleCommand("shortestTime", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("NAME_ROUTE", OracleType.Char, 50).Value = comboBox1NameR.Text;
                com.Parameters.Add("TIME_SHORTEST", OracleType.IntervalDayToSecond).Direction = ParameterDirection.Output;
                com.Parameters.Add("NUMBER_AUTO", OracleType.Char, 20).Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();
                txtTimeDop1.Text = com.Parameters["TIME_SHORTEST"].Value.ToString();
                txtNumAutoDop1.Text = com.Parameters["NUMBER_AUTO"].Value.ToString();
                ora.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                OracleCommand com = new OracleCommand("countAutoOnTheRoute", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("NAME_R", OracleType.Char, 50).Value = comboBox1NameR.Text;
                com.Parameters.Add("COUNT_AUTO", OracleType.Number).Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();
                countAutoDop2.Text = com.Parameters["COUNT_AUTO"].Value.ToString();
                ora.Close();
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

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            time_out = dataGridView1.Rows[i].Cells[e.ColumnIndex + 1].Value.ToString();
            time_in = dataGridView1.Rows[i].Cells[e.ColumnIndex + 2].Value.ToString();
            auto_id = dataGridView1.Rows[i].Cells[e.ColumnIndex + 3].Value.ToString();
            route_id = dataGridView1.Rows[i].Cells[e.ColumnIndex + 4].Value.ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
            ora.Open();
            OracleCommand com = new OracleCommand("dellPost", ora);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add("time_out_v", OracleType.Timestamp).Value = time_out;
            com.Parameters.Add("time_in_v", OracleType.Timestamp).Value = time_in;
            com.Parameters.Add("autoNum", OracleType.Char, 7).Value = auto_id;
            com.Parameters.Add("routeName", OracleType.Char, 50).Value = route_id;
            com.ExecuteNonQuery();
            ora.Close();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void DispForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet8.AUTO_PERSONNEL' table. You can move, or remove it, as needed.
            this.aUTO_PERSONNELTableAdapter.Fill(this.dataSet8.AUTO_PERSONNEL);
            // TODO: This line of code loads data into the 'dataSet7.ROUTES' table. You can move, or remove it, as needed.
            this.rOUTESTableAdapter2.Fill(this.dataSet7.ROUTES);
            // TODO: This line of code loads data into the 'dataSet6.ROUTES' table. You can move, or remove it, as needed.
            this.rOUTESTableAdapter1.Fill(this.dataSet6.ROUTES);
            // TODO: This line of code loads data into the 'dataSet5.AUTO' table. You can move, or remove it, as needed.
            this.aUTOTableAdapter1.Fill(this.dataSet5.AUTO);
            // TODO: This line of code loads data into the 'dataSet4.ROUTES' table. You can move, or remove it, as needed.
            this.rOUTESTableAdapter.Fill(this.dataSet4.ROUTES);
            // TODO: This line of code loads data into the 'dataSet3.AUTO' table. You can move, or remove it, as needed.
            this.aUTOTableAdapter.Fill(this.dataSet3.AUTO);
            // TODO: This line of code loads data into the 'dataSet2.AUTO' table. You can move, or remove it, as needed.

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
            ora.Open();
            try
            {
                OracleCommand com = new OracleCommand("updateJornalOutT", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("time_out_v", OracleType.Timestamp).Value = time_out;
                com.Parameters.Add("time_in_v", OracleType.Timestamp).Value = time_in;
                com.Parameters.Add("autoNum", OracleType.Char, 7).Value = auto_id;
                com.Parameters.Add("routeName", OracleType.Char, 50).Value = route_id;
                string dateOut = (dateTimePicker5OutUp.Value.Date + dateTimePicker6OutUp.Value.TimeOfDay).ToString("yyyy-MM-dd HH:mm:ss");
                com.Parameters.Add("T_OUT", OracleType.Char, 20).Value = dateOut;
                com.ExecuteNonQuery();
                updateForm u = new updateForm();
                u.Show();
            }
            catch (Exception ex)
            {
                ErrorTime er = new ErrorTime();
                er.Show();
            }
            ora.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
            ora.Open();
            try
            {
                OracleCommand com = new OracleCommand("updateJornalInT", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("time_out_v", OracleType.Timestamp).Value = time_out;
                com.Parameters.Add("time_in_v", OracleType.Timestamp).Value = time_in;
                com.Parameters.Add("autoNum", OracleType.Char, 7).Value = auto_id;
                com.Parameters.Add("routeName", OracleType.Char, 50).Value = route_id;
                string dateOut = (dateTimePicker7InUp.Value.Date + dateTimePicker8InUp.Value.TimeOfDay).ToString("yyyy-MM-dd HH:mm:ss");
                com.Parameters.Add("T_IN", OracleType.Char, 20).Value = dateOut;
                com.ExecuteNonQuery();
                updateForm u = new updateForm();
                u.Show();
            }
            catch (Exception ex)
            {
                ErrorTime er = new ErrorTime();
                er.Show();
            }
            ora.Close();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
            ora.Open();
            OracleCommand com = new OracleCommand("updateAutoInJ", ora);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add("time_out_v", OracleType.Timestamp).Value = time_out;
            com.Parameters.Add("time_in_v", OracleType.Timestamp).Value = time_in;
            com.Parameters.Add("autoNum", OracleType.Char, 7).Value = auto_id;
            com.Parameters.Add("routeName", OracleType.Char, 50).Value = route_id;
            com.Parameters.Add("numAuto", OracleType.Char, 20).Value = comboBoxNumAuto.Text;
            com.ExecuteNonQuery();
            updateForm u = new updateForm();
            u.Show();
            ora.Close();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
            ora.Open();
            OracleCommand com = new OracleCommand("updateNameRouteJornal", ora);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add("time_out_v", OracleType.Timestamp).Value = time_out;
            com.Parameters.Add("time_in_v", OracleType.Timestamp).Value = time_in;
            com.Parameters.Add("autoNum", OracleType.Char, 7).Value = auto_id;
            com.Parameters.Add("routeName", OracleType.Char, 50).Value = route_id;
            com.Parameters.Add("NameR", OracleType.Char, 60).Value = comboBoxNameR.Text;
            com.ExecuteNonQuery();
            updateForm u = new updateForm();
            u.Show();
            ora.Close();
        }
    }
}
