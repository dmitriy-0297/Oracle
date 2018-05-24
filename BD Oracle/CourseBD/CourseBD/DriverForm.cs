using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseBD
{
    public partial class DriverForm : Form
    {
        public DriverForm()
        {
            InitializeComponent();
            OracleConnection ora = new OracleConnection("DATA SOURCE = EC11; PASSWORD = qwerty; USER ID = Dmitriy;");
            ora.Open();
            OracleCommand com = new OracleCommand("selectAutoPersonel", ora);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add("reg", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapt = new OracleDataAdapter();
            adapt.SelectCommand = com;
            DataTable table = new DataTable();
            adapt.Fill(table);
            dataGridView1.DataSource = table;
            ora.Close();
            ora.Open();
            OracleCommand com_v1 = new OracleCommand("selectAuto", ora);
            com_v1.CommandType = System.Data.CommandType.StoredProcedure;
            com_v1.Parameters.Add("reg", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapt_v1 = new OracleDataAdapter();
            adapt_v1.SelectCommand = com_v1;
            DataTable table_v1 = new DataTable();
            adapt_v1.Fill(table_v1);
            dataGridView2.DataSource = table_v1;
            ora.Close();
            ora.Open();
            OracleCommand com_v2 = new OracleCommand("selectJornal", ora);
            com_v2.CommandType = System.Data.CommandType.StoredProcedure;
            com_v2.Parameters.Add("reg", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapt_v2 = new OracleDataAdapter();
            adapt_v2.SelectCommand = com_v2;
            DataTable table_v2 = new DataTable();
            adapt_v2.Fill(table_v2);
            dataGridView3.DataSource = table_v2;
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

        private void DriverForm_Load(object sender, EventArgs e)
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
            dataGridView1.DataSource = table;
            ora.Close();
        }

        private void button3_Click(object sender, EventArgs e)
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
            dataGridView2.DataSource = table;
            ora.Close();
        }

        private void button4_Click(object sender, EventArgs e)
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
            dataGridView3.DataSource = table;
            ora.Close();
        }
    }
}
