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
