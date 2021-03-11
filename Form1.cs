using ServiceStack;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Net;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace VAdmin
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            GetDataFromApi();
            // Load data from API
        }
        // Update all components on the main view
        public void ReloadContent(Root User)
        {
            //UserName.Text = User.results[0].name.first + " "
            //api_status.Text = User.User[0].users_name;
        }

        // Load data from API
        public void GetDataFromApi()
        {
            //Initialisation d'un web client
            var w = new WebClient();
            w.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.141 Safari/537.36 OPR/73.0.3856.400");
            string Response = null;
            //Tentative de contact à la BDD
            try
            {
                Response = w.DownloadString("http://127.0.0.1/api-veiko/isAPI_UP.php");
            }
            catch
            {}
            //Plusieurs cas de figure selon le retour de l'API
            switch (Response)
            {
                case "UP":
                    {
                        api_status.Text = "API Alive";
                        api_up_img.Visible = true;
                        break;
                    }
                case "DOWN":
                    {
                        api_status.Text = "API Down";
                        api_up_img.Visible = false;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("API Injoignable", "Erreur fatale", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        api_status.Text = "API Down";
                        api_up_img.Visible = false;
                        break;
                    }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public static string ConvertStringtoMD5(string strword)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(strword);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        private void but_Connection_Click(object sender, EventArgs e)
        {
            //Convertir l'entrée mdp de l'user en md5
            postPassword.Text = ConvertStringtoMD5(postPassword.Text);
            //Simuler un web client pour faire une requête post à l'api
            var w = new WebClient();
            w.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.141 Safari/537.36 OPR/73.0.3856.400");
            string Response = w.DownloadString("http://127.0.0.1/api-veiko/login.php?users_name=" + postLogin.Text + "&users_password=" + postPassword.Text);
            //Plusieurs cas de figure selon le retour de l'API
            switch (Response)
            {
                case "AccountNotRegistered":
                    {
                        MessageBox.Show("Account not registered");
                        break;
                    }
                case "PasswordError":
                    {
                        MessageBox.Show("Wrong password");
                        break;
                    }
                case "LoginSuccess":
                    {
                        MessageBox.Show("Bienvenue " + postLogin.Text);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Erreur remote server");
                        break;
                    }
            }
        }

        private void Reload_Click(object sender, EventArgs e)
        {
            GetDataFromApi();
        }

        private void UserName_Click(object sender, EventArgs e)
        {

        }

        private void postLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class User
    {
        public string users_id { get; set; }
        public string users_name { get; set; }
        public string users_address { get; set; }
        public string users_email { get; set; }
        public string users_password { get; set; }
        public string users_birthday { get; set; }
        public string avatar_url { get; set; }
        public string user_group { get; set; }
    }

    public class Root
    {
        public List<User> User { get; set; }
    }

}