using MySql.Data.MySqlClient;

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
    }
}
