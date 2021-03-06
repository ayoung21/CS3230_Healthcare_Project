﻿using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Healthcare_System.DAL
{
    /// <summary>
    /// Manages actions on the account table
    /// </summary>
    static class AccountDAL
    {

        /// <summary>Authenticates the specified username.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>1 if the username and password are validated, 0 if not</returns>
        public static int Authenticate(string username, string password)
        {
            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand("account_authenticate", connection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("givenusername", username));
                cmd.Parameters.Add(new MySqlParameter("givenpassword", password));

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count;
            }
        }

        /// <summary>Registers the specified username.</summary>
        /// <param name="username">The username.</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>True if registration is successful; false otherwise.</returns>
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

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@username", MySqlDbType.VarChar);
                cmd.Parameters["@username"].Value = username;

                connection.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                connection.Close();
                return count > 0;
            }
        }

        private static void registerUser(string username, string password)
        {
            string query = "INSERT INTO account VALUES(@username, SHA(@password))";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@username", MySqlDbType.VarChar);
                cmd.Parameters["@username"].Value = username;

                cmd.Parameters.Add("@password", MySqlDbType.TinyText);
                cmd.Parameters["@password"].Value = password;

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
