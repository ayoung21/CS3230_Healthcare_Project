using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Healthcare_System.DAL
{
    static class Helpers
    {
        private static bool isTableNameAllowed(string tableName)
        {
            IList<string> allowedTables = new List<string>();
            allowedTables.Add(AdministratorDAL.tableName);
            allowedTables.Add(NurseDAL.tableName);
            allowedTables.Add(PatientDAL.tableName);

            return allowedTables.Contains(tableName);
        }

        public static bool IsUserIdInTable(int userId, string table)
        {
            if (!isTableNameAllowed(table))
                throw new ArgumentOutOfRangeException("table name is invalid");

            string query = $"SELECT count(*) FROM {table} WHERE user_id = @userId;";

            using (MySqlCommand cmd = new MySqlCommand(query, DbConnection.GetConnection()))
            {
                cmd.Parameters.Add("@userId", MySqlDbType.Int32);
                cmd.Parameters["@userId"].Value = userId;

                cmd.Connection = DbConnection.GetConnection();

                cmd.Connection.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.Connection.Close();
                return count > 0;
            }
        }

        public static bool IsUsernameInTable(string username, string table)
        {
            if (!isTableNameAllowed(table))
                throw new ArgumentOutOfRangeException("table name is invalid");

            string query = $"SELECT count(*) FROM {table} WHERE username = @username;";

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

        public static int GetUserIdFromTable (string username, string table)
        {
            if (!isTableNameAllowed(table))
                throw new ArgumentOutOfRangeException("table name is invalid");

            string query = $"SELECT user_id FROM {table} WHERE username = @username;";

            using (MySqlCommand cmd = new MySqlCommand(query, DbConnection.GetConnection()))
            {
                cmd.Parameters.Add("@username", MySqlDbType.VarChar);
                cmd.Parameters["@username"].Value = username;

                cmd.Connection = DbConnection.GetConnection();

                cmd.Connection.Open();

                object queryResult = cmd.ExecuteScalar();
                int userId = (queryResult == DBNull.Value) ? -1 : Convert.ToInt32(queryResult);
                cmd.Connection.Close();
                return userId;
            }
        }
    }
}
