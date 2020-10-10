using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Healthcare_System.Model;
using MySql.Data.MySqlClient;

namespace Healthcare_System.DAL
{
    static class AccountDAL
    {

        /// <summary>Authenticates the specified username.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static int Authenticate(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM account WHERE username = @username AND password = @password";

            using (MySqlCommand cmd = new MySqlCommand(query, DbConnection.GetConnection()))
            {
                cmd.Parameters.Add("@username", MySqlDbType.VarChar);
                cmd.Parameters["@username"].Value = username;

                cmd.Parameters.Add("@password", MySqlDbType.TinyText);
                cmd.Parameters["@password"].Value = password;

                cmd.Connection = DbConnection.GetConnection();

                cmd.Connection.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                
                cmd.Connection.Close();
                return count;
            }
        }


        /// <summary>Registers the specified username.</summary>
        /// <param name="username">The username.</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>True if registration is successful; else otherwise.</returns>
        public static bool Register(string username, string password)
        {
            if (doesUserExist(username))
            {
                return false;
            }

            registerUser(username, password);
            return doesUserExist(username);
        }

        private static bool doesUserExist(string username)
        {
            string query = "SELECT count(*) FROM account WHERE username = @username";

            using (MySqlCommand cmd = new MySqlCommand(query, DbConnection.GetConnection()))
            {
                cmd.Parameters.Add("@username", MySqlDbType.VarChar);
                cmd.Parameters["@username"].Value = username;

                cmd.Connection = DbConnection.GetConnection();

                cmd.Connection.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.Connection.Close();
                return count > 0;
            }
        }

        private static void registerUser(string username, string password)
        {
            string query = "INSERT INTO account VALUES(@username, @password)";

            using (MySqlCommand cmd = new MySqlCommand(query, DbConnection.GetConnection()))
            {
                cmd.Parameters.Add("@username", MySqlDbType.VarChar);
                cmd.Parameters["@username"].Value = username;

                cmd.Parameters.Add("@password", MySqlDbType.TinyText);
                cmd.Parameters["@password"].Value = password;

                cmd.Connection = DbConnection.GetConnection();

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }
    }
}
