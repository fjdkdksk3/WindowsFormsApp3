using System;
using System.Data;
using System.Windows.Forms;

namespace AuthSystem
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            LoadUsers();
            cmbRole.Items.AddRange(new object[] { "Администратор", "Пользователь" });
        }

        private void LoadUsers()
        {
            DataTable dt = DatabaseHelper.GetUsers();
            dgvUsers.DataSource = dt;
            dgvUsers.Columns["ID"].Visible = false;
            dgvUsers.Columns["Заблокирован"].HeaderText = "Заблокирован";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;
            string role = cmbRole.Text;

            if (login == "" || password == "" || role == "")
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DatabaseHelper.UserExists(login))
            {
                MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DatabaseHelper.AddUser(login, password, role);
            MessageBox.Show("Пользователь добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            LoadUsers();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пользователя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["ID"].Value);
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;
            string role = cmbRole.Text;
            bool blocked = chkBlocked.Checked;

            if (login == "" || password == "" || role == "")
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatabaseHelper.UpdateUser(id, login, password, role, blocked);
            MessageBox.Show("Данные обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            LoadUsers();
        }

        private void btnUnblock_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пользователя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["ID"].Value);
            DatabaseHelper.UnblockUser(id);
            MessageBox.Show("Пользователь разблокирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUsers();
            ClearFields();
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvUsers.SelectedRows[0];
                txtLogin.Text = row.Cells["Логин"].Value.ToString();
                cmbRole.Text = row.Cells["Роль"].Value.ToString();
                chkBlocked.Checked = Convert.ToBoolean(row.Cells["Заблокирован"].Value);
                txtPassword.Clear();
            }
        }

        private void ClearFields()
        {
            txtLogin.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;
            chkBlocked.Checked = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
            ClearFields();
        }
    }
}