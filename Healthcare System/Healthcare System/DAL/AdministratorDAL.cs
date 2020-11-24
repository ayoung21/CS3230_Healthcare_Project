using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.DAL
{
    /// <summary>
    /// Manages actions on the administrator table
    /// </summary>
    static class AdministratorDAL
    {
        public static readonly string tableName = "administrator";

        /// <summary>
        ///     Registers a new administrator
        /// </summary>
        /// <param name="userId">The userId of the user to make an admin</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     true if successful; false if userId is already associated with an admin account
        ///     or another error occurs
        /// </returns>
        public static bool Register(int userId, string username)
        {
            if (UserHelpers.IsUserIdInTable(userId, tableName))
            {
                return false;
            }

            string query = $"INSERT INTO {tableName} VALUES(@userId, @username);";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@userId", MySqlDbType.Int32);
                cmd.Parameters["@userId"].Value = userId;

                cmd.Parameters.Add("@username", MySqlDbType.VarChar);
                cmd.Parameters["@username"].Value = username;

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            return UserHelpers.IsUserIdInTable(userId, tableName);
        }

        /// <summary>
        ///     Gets the number of administrators.
        /// </summary>
        /// <returns>the number of administrators</returns>
        public static int GetNumberAdministrators()
        {
            string query = $"SELECT COUNT(user_id) FROM {tableName};";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                connection.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
                return count;
            }
        }
    }
}
