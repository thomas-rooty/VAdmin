using ServiceStack;
using ServiceStack.Text;
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
            GetDataFromApi();
            // Load data from API
            GetDataFromApi();
        }
        // Update all components on the main view
        public void ReloadContent(Root User)
        {
            UserName.Text = User.results[0].name.first + " " + User.results[0].name.last;
        }

        // Load data from API
        public void GetDataFromApi()
        {
            string url = "https://randomuser.me/api/";
            var LoadedUser = new Root();

            // Try to get data
            try
            {
                LoadedUser = url.GetJsonFromUrl().FromJson<Root>();
                LoadedUser.PrintDump();
                ReloadContent(LoadedUser);
            }
            // Gest error
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
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
                isAccountValid.Visible = false;
            } else
            {
                isAccountValid.Visible = true;
            }
        }
    }
    public class Root
    {
        public string users_id { get; set; }
        public string users_name { get; set; }
        public string users_address { get; set; }
        public string users_email { get; set; }
        public string users_password { get; set; }
        public string users_birthday { get; set; }
        public string user_group { get; set; }
        public string avatar_url { get; set; }
    }
}
