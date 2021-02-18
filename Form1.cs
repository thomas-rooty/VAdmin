using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VAdmin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void but_Connection_Click(object sender, EventArgs e)
        {
            string login = postLogin.Text;
            string password = postPassword.Text;

            if(login == "admin" && password == "admin")
            {
                MessageBox.Show("Condition testée");
            } else
            {
                MessageBox.Show("Mauvais identifiants");
            }
        }
    }
}
