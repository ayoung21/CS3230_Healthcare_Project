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
    class LabDAL
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

        public static int OrderTest(int patientId, DateTime appointmentDateTime, List<LabTest> tests)
        {
            //TODO
            // - must add to the has_tests table and lab_test_order table
            // - returns the test order ID
            return 0;
        }

        public static bool AddResults(bool isAbnormal, string results, int testOrderId)
        {
            //TODO
            return false;
        }

        public static LabTestResults GetTestResults(int testOrderId, int testCode)
        {
            //TODO
            return null;
        }
    }
}
