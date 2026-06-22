using System;
using System.Drawing;
using System.Windows.Forms;

namespace AuthSystem
{
    partial class AdminForm
    {
        private DataGridView dgvUsers;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private ComboBox cmbRole;
        private CheckBox chkBlocked;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnUnblock;
        private Button btnRefresh;
        private Label label1;
        private Label label2;
        private Label label3;

        private void InitializeComponent()
        {
            this.dgvUsers = new DataGridView();
            this.txtLogin = new TextBox();
            this.txtPassword = new TextBox();
            this.cmbRole = new ComboBox();
            this.chkBlocked = new CheckBox();
            this.btnAdd = new Button();
            this.btnUpdate = new Button();
            this.btnUnblock = new Button();
            this.btnRefresh = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();

            this.dgvUsers.Location = new Point(12, 12);
            this.dgvUsers.Size = new Size(500, 200);
            this.dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.SelectionChanged += new EventHandler(this.dgvUsers_SelectionChanged);

            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 230);
            this.label1.Text = "Логин:";

            this.txtLogin.Location = new Point(70, 227);
            this.txtLogin.Size = new Size(150, 20);

            this.label2.AutoSize = true;
            this.label2.Location = new Point(12, 260);
            this.label2.Text = "Пароль:";

            this.txtPassword.Location = new Point(70, 257);
            this.txtPassword.Size = new Size(150, 20);

            this.label3.AutoSize = true;
            this.label3.Location = new Point(12, 290);
            this.label3.Text = "Роль:";

            this.cmbRole.Location = new Point(70, 287);
            this.cmbRole.Size = new Size(150, 21);
            this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;

            this.chkBlocked.Location = new Point(70, 315);
            this.chkBlocked.Text = "Заблокирован";

            this.btnAdd.Location = new Point(250, 225);
            this.btnAdd.Size = new Size(120, 30);
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location = new Point(250, 260);
            this.btnUpdate.Size = new Size(120, 30);
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);

            this.btnUnblock.Location = new Point(250, 295);
            this.btnUnblock.Size = new Size(120, 30);
            this.btnUnblock.Text = "Снять блокировку";
            this.btnUnblock.Click += new EventHandler(this.btnUnblock_Click);

            this.btnRefresh.Location = new Point(250, 330);
            this.btnRefresh.Size = new Size(120, 30);
            this.btnRefresh.Text = "Обновить список";
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            this.ClientSize = new Size(524, 380);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnUnblock);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.chkBlocked);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvUsers);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Администратор";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}