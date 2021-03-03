﻿using ServiceStack;
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
            UserName.Text = User.User[0].users_name;
        }

        // Load data from API
        public void GetDataFromApi()
        {
            string url = "http://localhost/api-veiko/user/1";
            var LoadedUser = new Root();

            // Try to get data
            try
            {
                LoadedUser = url.GetStringFromUrl().FromJson<Root>();
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