using Healthcare_System.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Healthcare_System.DAL
{

    /// <summary>
    /// Manages actions on related to lab tests.
    /// </summary>
    static class LabTestDAL
    {

        /// <summary>
        /// Gets all tests from the lab_test table.
        /// </summary>
        /// <returns>A list of all possible tests</returns>
        public static List<LabTest> GetAllTests()
        {
            string query = "SELECT * FROM lab_test;";

            List<LabTest> labTests = new List<LabTest>();

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                connection.Open();

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int code = (dataReader["code"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["code"]);
                        string name = (dataReader["name"] == DBNull.Value) ? default : Convert.ToString(dataReader["name"]);

                        labTests.Add(new LabTest(code, name));
                    }
                }
            }
            return labTests;
        }

        /// <summary>
        /// Gets the name of the test that corresponds with the given code.
        /// </summary>
        /// <param name="testCode">The test code.</param>
        /// <returns>the name of the test that corresponds with the given code</returns>
        public static string GetTestName(int testCode)
        {
            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                connection.Open();

                using MySqlCommand cmd = new MySqlCommand("lab_test_get_name", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new MySqlParameter("test_code", testCode));

                object queryResult = cmd.ExecuteScalar();
                string name = (queryResult == DBNull.Value) ? null : Convert.ToString(queryResult);

                return name;
            }
        }
    }
}
