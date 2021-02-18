
namespace VAdmin
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLogin = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.Label();
            this.postLogin = new System.Windows.Forms.TextBox();
            this.postPassword = new System.Windows.Forms.TextBox();
            this.but_Connection = new System.Windows.Forms.Button();
            this.isAccountValid = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.Label();
            this.Reload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLogin
            // 
            this.txtLogin.AutoSize = true;
            this.txtLogin.Location = new System.Drawing.Point(80, 43);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(47, 16);
            this.txtLogin.TabIndex = 0;
            this.txtLogin.Text = "Login :";
            // 
            // txtPassword
            // 
            this.txtPassword.AutoSize = true;
            this.txtPassword.Location = new System.Drawing.Point(80, 89);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(74, 16);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "Password :";
            this.txtPassword.Click += new System.EventHandler(this.label2_Click);
            // 
            // postLogin
            // 
            this.postLogin.Location = new System.Drawing.Point(188, 39);
            this.postLogin.Margin = new System.Windows.Forms.Padding(4);
            this.postLogin.Name = "postLogin";
            this.postLogin.Size = new System.Drawing.Size(132, 22);
            this.postLogin.TabIndex = 2;
            // 
            // postPassword
            // 
            this.postPassword.Location = new System.Drawing.Point(188, 85);
            this.postPassword.Margin = new System.Windows.Forms.Padding(4);
            this.postPassword.Name = "postPassword";
            this.postPassword.PasswordChar = '•';
            this.postPassword.Size = new System.Drawing.Size(132, 22);
            this.postPassword.TabIndex = 3;
            // 
            // but_Connection
            // 
            this.but_Connection.Location = new System.Drawing.Point(111, 160);
            this.but_Connection.Margin = new System.Windows.Forms.Padding(4);
            this.but_Connection.Name = "but_Connection";
            this.but_Connection.Size = new System.Drawing.Size(180, 28);
            this.but_Connection.TabIndex = 4;
            this.but_Connection.Text = "Se connecter";
            this.but_Connection.UseVisualStyleBackColor = true;
            this.but_Connection.Click += new System.EventHandler(this.but_Connection_Click);
            // 
            // isAccountValid
            // 
            this.isAccountValid.AutoSize = true;
            this.isAccountValid.ForeColor = System.Drawing.Color.Red;
            this.isAccountValid.Location = new System.Drawing.Point(84, 121);
            this.isAccountValid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.isAccountValid.Name = "isAccountValid";
            this.isAccountValid.Size = new System.Drawing.Size(212, 20);
            this.isAccountValid.TabIndex = 5;
            this.isAccountValid.Text = "Le compte spécifié n\'est pas valide";
            this.isAccountValid.UseCompatibleTextRendering = true;
            this.isAccountValid.Visible = false;
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(409, 39);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(74, 16);
            this.UserName.TabIndex = 6;
            this.UserName.Text = "UserName";
            this.UserName.Click += new System.EventHandler(this.UserName_Click);
            // 
            // Reload
            // 
            this.Reload.Location = new System.Drawing.Point(412, 160);
            this.Reload.Name = "Reload";
            this.Reload.Size = new System.Drawing.Size(75, 23);
            this.Reload.TabIndex = 7;
            this.Reload.Text = "Reload";
            this.Reload.UseVisualStyleBackColor = true;
            this.Reload.Click += new System.EventHandler(this.Reload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 203);
            this.Controls.Add(this.Reload);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.isAccountValid);
            this.Controls.Add(this.but_Connection);
            this.Controls.Add(this.postPassword);
            this.Controls.Add(this.postLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtLogin);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "VAdmin - Connexion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtLogin;
        private System.Windows.Forms.Label txtPassword;
        private System.Windows.Forms.TextBox postLogin;
        private System.Windows.Forms.TextBox postPassword;
        private System.Windows.Forms.Button but_Connection;
        private System.Windows.Forms.Label isAccountValid;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Button Reload;
    }
}

