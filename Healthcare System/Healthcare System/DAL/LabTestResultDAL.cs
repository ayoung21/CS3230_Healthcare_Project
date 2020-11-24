using Healthcare_System.Model;
using MySql.Data.MySqlClient;
using System;

namespace Healthcare_System.DAL
{
    /// <summary>
    /// Manages actions on related to lab tests results table.
    /// </summary>
    static class LabTestResultDAL
    {

        /// <summary>Adds the results.</summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="testCode">The test code.</param>
        /// <param name="results">The results.</param>
        /// <param name="isAbnormal">Whether the results are abnormal/</param>
        /// <param name="takenOn">The taken on.</param>
        /// <returns>true if results have been added, false otherwise</returns>
        public static bool AddResults(int orderId, int testCode, string results, bool isAbnormal, DateTime takenOn)
        {
            string query = "INSERT INTO lab_test_result VALUES(@order_id, @test_code, @results, @is_abnormal, @taken_on);";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@order_id", MySqlDbType.Int32);
                cmd.Parameters["@order_id"].Value = orderId;

                cmd.Parameters.Add("@test_code", MySqlDbType.Int32);
                cmd.Parameters["@test_code"].Value = testCode;

                cmd.Parameters.Add("@results", MySqlDbType.VarChar);
                cmd.Parameters["@results"].Value = results;

                cmd.Parameters.Add("@is_abnormal", MySqlDbType.Int16);
                cmd.Parameters["@is_abnormal"].Value = isAbnormal;

                cmd.Parameters.Add("@taken_on", MySqlDbType.DateTime);
                cmd.Parameters["@taken_on"].Value = takenOn;

                connection.Open();
                int result = cmd.ExecuteNonQuery();

                return result == 1;
            }
        }


        /// <summary>Updates the results.</summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="testCode">The test code.</param>
        /// <param name="results">The results.</param>
        /// <param name="isAbnormal">Whether the results are abnormal/</param>
        /// <param name="takenOn">The taken on.</param>
        /// <returns>true if results are updated, false otherwise</returns>
        public static bool UpdateResults(int orderId, int testCode, string results, bool isAbnormal, DateTime takenOn)
        {
            string query = "UPDATE lab_test_result " +
                "SET results = @results, is_abnormal = @is_abnormal, datetime_taken = @datetime_taken " +
                "WHERE order_id = @order_id AND test_code = @test_code;";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@results", MySqlDbType.VarChar);
                cmd.Parameters["@results"].Value = results;

                cmd.Parameters.Add("@is_abnormal", MySqlDbType.Int16);
                cmd.Parameters["@is_abnormal"].Value = isAbnormal;

                cmd.Parameters.Add("@datetime_taken", MySqlDbType.DateTime);
                cmd.Parameters["@datetime_taken"].Value = takenOn;

                cmd.Parameters.Add("@order_id", MySqlDbType.Int32);
                cmd.Parameters["@order_id"].Value = orderId;

                cmd.Parameters.Add("@test_code", MySqlDbType.Int32);
                cmd.Parameters["@test_code"].Value = testCode;

                connection.Open();
                int result = cmd.ExecuteNonQuery();

                return result == 1;
            }
        }


        /// <summary>Gets the results.</summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="testCode">The test code.</param>
        /// <returns>Lab test results</returns>
        public static LabTestResults GetResults(int orderId, int testCode)
        {
            string query = "SELECT results, is_abnormal, datetime_taken FROM lab_test_result " +
                "WHERE order_id = @order_id AND test_code = @test_code;";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@order_id", MySqlDbType.Int32);
                cmd.Parameters["@order_id"].Value = orderId;

                cmd.Parameters.Add("@test_code", MySqlDbType.Int32);
                cmd.Parameters["@test_code"].Value = testCode;

                connection.Open();

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    string results = (dataReader["results"] == DBNull.Value) ? null : Convert.ToString(dataReader["results"]);
                    bool isAbnormal = (dataReader["is_abnormal"] == DBNull.Value) ? default : Convert.ToBoolean(dataReader["is_abnormal"]);
                    DateTime takenOn = (dataReader["datetime_taken"] == DBNull.Value) ? default : Convert.ToDateTime(dataReader["datetime_taken"]);

                    return new LabTestResults(results, isAbnormal, takenOn);
                }

                return null;
            }
        }
    }
}
