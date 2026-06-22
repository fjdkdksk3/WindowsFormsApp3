using System;
using System.Drawing;
using System.Windows.Forms;

namespace AuthSystem
{
    partial class LoginForm
    {
        private TextBox txtLogin;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label label1;
        private Label label2;

        private void InitializeComponent()
        {
            this.txtLogin = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new Point(20, 25);
            this.label1.Text = "Логин:";

            // txtLogin
            this.txtLogin.Location = new Point(80, 22);
            this.txtLogin.Size = new Size(150, 20);

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new Point(20, 55);
            this.label2.Text = "Пароль:";

            // txtPassword
            this.txtPassword.Location = new Point(80, 52);
            this.txtPassword.Size = new Size(150, 20);
            this.txtPassword.UseSystemPasswordChar = true;

            // btnLogin
            this.btnLogin.Location = new Point(115, 90);
            this.btnLogin.Size = new Size(80, 30);
            this.btnLogin.Text = "Войти";
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // LoginForm
            this.ClientSize = new Size(260, 140);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}