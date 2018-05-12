using System;
using System.Data.OracleClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseBD
{
    public partial class DirForm : Form
    {
        public DirForm()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
            ora.Open();
            Conn c = new Conn();
            c.Show();
            ora.Close();
        }

        private void PremGo_Click(object sender, EventArgs e)
        {
            if (time_start.Text == "" || time_end.Text == "" || sumPrem.Text == "")
            {
                ErrorInputLable er = new ErrorInputLable();
                er.Show();
            }
            else
            {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                OracleCommand com = new OracleCommand("DRIVER_CASH", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("START_DATE", OracleType.Timestamp).Value = time_start.Text;
                com.Parameters.Add("END_DATE", OracleType.Timestamp).Value = time_end.Text;
                com.Parameters.Add("CASH", OracleType.Number).Value = sumPrem.Text;
                com.Parameters.Add("FIRST_PERSONNEL_V", OracleType.Char, 30).Direction = ParameterDirection.Output;
                com.Parameters.Add("SECOND_PERSONNEL_V", OracleType.Char, 30).Direction = ParameterDirection.Output;
                com.Parameters.Add("THIRD_PERSONNEL_V", OracleType.Char, 30).Direction = ParameterDirection.Output;
                com.Parameters.Add("PRIZE_ONE", OracleType.Float).Direction = ParameterDirection.Output;
                com.Parameters.Add("PRIZE_TWO", OracleType.Float).Direction = ParameterDirection.Output;
                com.Parameters.Add("PRIZE_FREE", OracleType.Float).Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();
                DataTable tabla = new DataTable();
                DataColumn Name = new DataColumn("Фамилия", typeof(string));
                DataColumn Cash = new DataColumn("Премия", typeof(string));
                tabla.Columns.AddRange(new DataColumn[] { Name, Cash });
                DataRow row1 = tabla.NewRow();
                row1["Фамилия"] = com.Parameters["FIRST_PERSONNEL_V"].Value.ToString();
                row1["Премия"] = com.Parameters["PRIZE_ONE"].Value.ToString();
                DataRow row2 = tabla.NewRow();
                row2["Фамилия"] = com.Parameters["SECOND_PERSONNEL_V"].Value.ToString();
                row2["Премия"] = com.Parameters["PRIZE_TWO"].Value.ToString();
                DataRow row3 = tabla.NewRow();
                row3["Фамилия"] = com.Parameters["THIRD_PERSONNEL_V"].Value.ToString();
                row3["Премия"] = com.Parameters["PRIZE_FREE"].Value.ToString();
                tabla.Rows.Add(row1);
                tabla.Rows.Add(row2);
                tabla.Rows.Add(row3);
                OracleDataAdapter adapt = new OracleDataAdapter();
                adapt.SelectCommand = com;
                adapt.Fill(tabla);
                dataGridView1.DataSource = tabla;
                ora.Close();
            }
        }

        private void time_start_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DirForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void DirForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
            dataGridView2.DataSource = table;
            ora.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
            ora.Open();
            OracleCommand com = new OracleCommand("worst_worker", ora);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add("WORKER", OracleType.Char, 20).Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            Worker.Text = com.Parameters["WORKER"].Value.ToString();
            ora.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (LastName.Text == "")
            {
                ErrorInputLable er = new ErrorInputLable();
                er.Show();
            }
            else
            {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                OracleCommand com = new OracleCommand("deleteAutoPers", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("lastName", OracleType.Char, 20).Value = LastName.Text;
                com.ExecuteNonQuery();
                DelWokerForm d = new DelWokerForm();
                d.Show();
                ora.Close();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtFam.Text == "" || txtName.Text == "" || txtOtg.Text == "")
            {
                ErrorInputLable er = new ErrorInputLable();
                er.Show();
            }
            else
            {
                OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
                ora.Open();
                OracleCommand com = new OracleCommand("addAutoPers", ora);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("FIRST_N", OracleType.Char, 20).Value = txtName.Text;
                com.Parameters.Add("LAST_N", OracleType.Char, 20).Value = txtFam.Text;
                com.Parameters.Add("PATHER_N", OracleType.Char, 20).Value = txtOtg.Text;
                com.ExecuteNonQuery();
                AddForm a = new AddForm();
                a.Show();
                ora.Close();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
