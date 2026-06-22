using System;
using System.Data;
using System.Data.SqlClient;

namespace AuthSystem
{
    public static class DatabaseHelper
    {
        private static string connectionString =
            "Data Source=localhost;Initial Catalog=TestDB;Integrated Security=True";

        public static bool CheckUser(string login, string password, out string role, out bool blocked)
        {
            role = "";
            blocked = false;

            string query = "SELECT Роль, Заблокирован FROM Пользователи WHERE Логин=@login AND Пароль=@pass";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@pass", password);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    role = reader["Роль"].ToString();
                    blocked = Convert.ToBoolean(reader["Заблокирован"]);
                    return true;
                }
                return false;
            }
        }

        public static DataTable GetUsers()
        {
            string query = "SELECT ID, Логин, Роль, Заблокирован FROM Пользователи";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static bool UserExists(string login)
        {
            string query = "SELECT COUNT(*) FROM Пользователи WHERE Логин=@login";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@login", login);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public static void AddUser(string login, string password, string role)
        {
            string query = "INSERT INTO Пользователи (Логин, Пароль, Роль, Заблокирован) VALUES (@login, @pass, @role, 0)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.Parameters.AddWithValue("@role", role);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateUser(int id, string login, string password, string role, bool blocked)
        {
            string query = "UPDATE Пользователи SET Логин=@login, Пароль=@pass, Роль=@role, Заблокирован=@blocked WHERE ID=@id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.Parameters.AddWithValue("@blocked", blocked);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UnblockUser(int id)
        {
            string query = "UPDATE Пользователи SET Заблокирован=0 WHERE ID=@id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}