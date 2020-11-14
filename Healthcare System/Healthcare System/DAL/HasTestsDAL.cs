using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.DAL
{
    static class HasTestsDAL
    {
        public static bool AddTestToOrder(int orderId, int testCode)
        {
            string query = "INSERT INTO has_tests VALUES(@order_id, @test_code);";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@order_id", MySqlDbType.Int32);
                cmd.Parameters["@order_id"].Value = orderId;

                cmd.Parameters.Add("@test_code", MySqlDbType.Int32);
                cmd.Parameters["@test_code"].Value = testCode;

                connection.Open();
                int result = cmd.ExecuteNonQuery();

                return result == 1;
            }
        }

        public static List<int> GetTestCodesFromOrder(int orderId)
        {
            string query = "SELECT test_code FROM has_tests WHERE order_id = @order_id;";

            List<int> testCodes = new List<int>();

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@order_id", MySqlDbType.Int32);
                cmd.Parameters["@order_id"].Value = orderId;

                connection.Open();

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int testCode = (dataReader["test_code"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["test_code"]);

                        testCodes.Add(testCode);
                    }
                }
            }

            return testCodes;
        }
    }
}
