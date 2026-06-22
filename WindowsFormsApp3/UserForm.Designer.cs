using System;
using System.Drawing;
using System.Windows.Forms;

namespace AuthSystem
{
    partial class UserForm
    {
        private Label label1;
        private Button btnExit;

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.btnExit = new Button();
            this.SuspendLayout();

            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new Point(80, 50);
            this.label1.Text = "Добро пожаловать!";

            this.btnExit.Location = new Point(110, 100);
            this.btnExit.Size = new Size(100, 30);
            this.btnExit.Text = "Выйти";
            this.btnExit.Click += new EventHandler(this.btnExit_Click);

            this.ClientSize = new Size(320, 170);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Пользователь";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}