using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.DAL
{
    class PatientDAL
    {
        public static readonly string tableName = "patient";

        public static bool Register(int userId)
        {
            if (Helpers.IsUserIdInTable(userId, tableName))
            {
                return false;
            }

            string query = $"INSERT INTO {tableName}(user_id) VALUES(@userId);";

            using (MySqlCommand cmd = new MySqlCommand(query, DbConnection.GetConnection()))
            {
                cmd.Parameters.Add("@userId", MySqlDbType.Int32);
                cmd.Parameters["@userId"].Value = userId;

                cmd.Connection = DbConnection.GetConnection();

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }

            return Helpers.IsUserIdInTable(userId, tableName);
        }
    }
}
