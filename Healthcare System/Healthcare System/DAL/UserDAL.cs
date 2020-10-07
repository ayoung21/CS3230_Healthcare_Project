using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare_System.Model;
using MySql.Data.MySqlClient;

namespace Healthcare_System.DAL
{
    static class UserDAL
    {

        /// <summary>Authenticates the specified email.</summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static int Authenticate(string email, string password)
        {
            string query = "SELECT count(*) FROM users WHERE email = @email AND password = @password";

            using (MySqlCommand cmd = new MySqlCommand(query, DbConnection.GetConnection()))
            {
                cmd.Parameters.Add("@email", MySqlDbType.VarChar);
                cmd.Parameters["@email"].Value = email;

                cmd.Parameters.Add("@password", MySqlDbType.TinyText);
                cmd.Parameters["@password"].Value = password;

                cmd.Connection = DbConnection.GetConnection();

                cmd.Connection.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                
                cmd.Connection.Close();
                return count;
            }
        }

        public static void Register(string username, string email, string password)
        {
            string query = "INSERT INTO users(username, email, password) VALUES(@username, @email, @password)";

            using (MySqlCommand cmd = new MySqlCommand(query, DbConnection.GetConnection()))
            {
                cmd.Parameters.Add("@username", MySqlDbType.VarChar);
                cmd.Parameters["@username"].Value = username;

                cmd.Parameters.Add("@email", MySqlDbType.VarChar);
                cmd.Parameters["@email"].Value = email;

                cmd.Parameters.Add("@password", MySqlDbType.TinyText);
                cmd.Parameters["@password"].Value = password;

                cmd.Connection = DbConnection.GetConnection();

                cmd.Connection.Open();
                int testing = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                Console.WriteLine("REGISTER: " + testing);
            }
        }
    }
}
