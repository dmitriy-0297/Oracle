using System;
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
    public partial class StartWin : Form
    {
        public StartWin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((addUser.Text == "Диспетчер" || addUser.Text == "диспетчер") && (addPassword.Text == "Диспетчер" || addPassword.Text == "диспетчер"))
            {
                DispForm DispF = new DispForm();
                DispF.Show();
            }
            else if ((addUser.Text == "Директор" || addUser.Text == "директор") && (addPassword.Text == "Директор" || addPassword.Text == "директор"))
            { 
                DirForm DirF = new DirForm();
                DirF.Show();
            }
            else if ((addUser.Text == "Водитель" || addUser.Text == "водитель") && (addPassword.Text == "Водитель" || addPassword.Text == "водитель"))
            {
                DriverForm DriverF = new DriverForm();
                DriverF.Show();
            }
            else
            {
                ErrorInp Er = new ErrorInp();
                Er.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BTExit_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
            {
                Application.Exit();
            }
        }

        private void StartWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            WhatExit w = new WhatExit();
            w.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void StartWin_Load(object sender, EventArgs e)
        {

        }
    }
}
