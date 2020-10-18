using Healthcare_System.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Healthcare_System.DAL
{
    /// <summary>
    /// Manages actions on the patient table.
    /// </summary>
    class PatientDAL
    {
        public static readonly string tableName = "patient";

        /// <summary>
        ///     Registers a new patient.
        /// </summary>
        /// <param name="userId">The userId in the user table to make a patient account for.</param>
        /// <returns>
        ///     True if successful; false if the userId already exists in the patient table
        ///     or another issue occured
        /// </returns>
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

        public static List<int> GetSearchResults(string lastName, string firstName, DateTime? dob)
        {
            if (string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && dob == null)
                throw new ArgumentException("At least one parameter is required to search");

            StringBuilder query = new StringBuilder("SELECT u.user_id FROM user u, patient p WHERE u.user_id = p.user_id");
            if (!string.IsNullOrEmpty(lastName))
                query.Append(" AND u.last_name = @lastName");
            if (!string.IsNullOrEmpty(firstName))
                query.Append(" AND u.first_name = @firstName");
            if (dob != null)
                query.Append(" AND dob = @dob");
            query.Append(";");

            List<int> matchingUserIds = new List<int>();

            using (MySqlCommand cmd = new MySqlCommand(query.ToString(), DbConnection.GetConnection()))
            {
                if (!string.IsNullOrEmpty(lastName))
                {
                    cmd.Parameters.Add("@lastName", MySqlDbType.VarChar);
                    cmd.Parameters["@lastName"].Value = lastName;
                }
                if (!string.IsNullOrEmpty(firstName))
                {
                    cmd.Parameters.Add("@firstName", MySqlDbType.VarChar);
                    cmd.Parameters["@firstName"].Value = firstName;
                }
                if (dob != null)
                {
                    cmd.Parameters.Add("@dob", MySqlDbType.Date);
                    cmd.Parameters["@dob"].Value = dob;
                }

                cmd.Connection = DbConnection.GetConnection();

                cmd.Connection.Open();

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int userId = (dataReader["user_id"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["user_id"]);
                        matchingUserIds.Add(userId);
                    }
                    
                }
                
                cmd.Connection.Close();

                return matchingUserIds;
            }
        }
    }
}
