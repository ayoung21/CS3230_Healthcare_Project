using Healthcare_System.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static string GetTestName(int testCode)
        {
            string query = "SELECT name FROM lab_test WHERE code = @code;";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@code", MySqlDbType.Int32);
                cmd.Parameters["@code"].Value = testCode;

                connection.Open();

                object queryResult = cmd.ExecuteScalar();
                string name = (queryResult == DBNull.Value) ? null : Convert.ToString(queryResult);

                return name;
            }
        }
    }
}
