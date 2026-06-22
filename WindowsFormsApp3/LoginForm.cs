using System;
using System.Windows.Forms;

namespace AuthSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Проверка заполнения полей
            if (txtLogin.Text.Trim() == "")
            {
                MessageBox.Show("Введите логин!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLogin.Focus();
                return;
            }

            if (txtPassword.Text == "")
            {
                MessageBox.Show("Введите пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Проверка в БД
            string role;
            bool blocked;

            if (DatabaseHelper.CheckUser(txtLogin.Text, txtPassword.Text, out role, out blocked))
            {
                if (blocked)
                {
                    MessageBox.Show("Ваш аккаунт заблокирован!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Вы успешно авторизовались!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Открываем нужную форму
                if (role == "Администратор")
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                }
                else
                {
                    UserForm userForm = new UserForm();
                    userForm.Show();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Вы ввели неверный логин или пароль. Пожалуйста проверьте ещё раз введенные данные.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
    }
}