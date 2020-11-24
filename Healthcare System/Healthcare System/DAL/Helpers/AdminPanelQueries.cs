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
    }
}
