using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.DAL.Helpers
{
    /// <summary>
    /// Contains queries for the admin panel
    /// </summary>
    static class AdminPanelQueries
    {
        /// <summary>
        /// Executes a user-defined query
        /// </summary>
        /// <param name="queryInput">The query input.</param>
        /// <returns>
        ///     A data table containing the results of the query if successful,
        ///     null if not
        /// </returns>
        public static DataTable ExecuteCustomQuery(string queryInput)
        {
            var dataTable = new DataTable();
            try
            {
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    var query = $@"{queryInput}";

                    cmd.CommandText = query;

                    using (var dataAdapter = new MySqlDataAdapter(cmd))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
            }
            catch (MySqlException)
            {
                return null;
            }

            return dataTable;
        }

        /// <summary>
        /// Generates a report of all visits between the start and end date
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>A DataTable containing the admin report data</returns>
        public static DataTable GenerateReport(DateTime startDate, DateTime endDate)
        {
            var dataTable = new DataTable();
            string query = "SELECT " +
                "v.datetime AS visit_datetime, " +
                "v.patient_id, " +
                "CONCAT(up.last_name, ', ', up.first_name) AS patient_name, " +
                "CONCAT(ud.last_name, ', ', ud.first_name) AS doctor_name, " +
                "CONCAT(un.last_name, ', ', un.first_name) AS nurse_name, " +
                "v.diagnoses " +
                "FROM visit v, patient p, user up, doctor d, user ud, user un " +
                "WHERE " +
                "v.patient_id = p.patient_id AND " +
                "up.user_id = p.user_id AND " +
                "v.doctor_id = d.doctor_id AND " +
                "ud.user_id = d.user_id AND " +
                "v.nurse_user_id = un.user_id AND " +
                "v.datetime BETWEEN DATE(@start_date) AND DATE(@end_date) " +
                "ORDER BY DATE(v.datetime), up.last_name";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@start_date", MySqlDbType.DateTime);
                cmd.Parameters["@start_date"].Value = $"{startDate.Year}-{startDate.Month}-{startDate.Day} 00:00:00";

                cmd.Parameters.Add("@end_date", MySqlDbType.DateTime);
                cmd.Parameters["@end_date"].Value = $"{endDate.Year}-{endDate.Month}-{endDate.Day} 23:59:59";

                connection.Open();

                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataTable.Load(dataReader);
            }

            return dataTable;
        }
    }
}
