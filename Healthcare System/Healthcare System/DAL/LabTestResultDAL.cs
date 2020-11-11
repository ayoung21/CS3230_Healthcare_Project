using MySql.Data.MySqlClient;
using Healthcare_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.DAL
{
    static class LabTestResultDAL
    {
        public static bool AddResults(int orderId, int testCode, string results, bool isAbnormal)
        {
            string query = "INSERT INTO lab_test_result VALUES(@order_id, @test_code, @results, @is_abnormal);";

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

                connection.Open();
                int result = cmd.ExecuteNonQuery();

                return result == 1;
            }
        }

        public static LabTestResults GetResults(int orderId, int testCode)
        {
            string query = "SELECT results, is_abnormal FROM lab_test_result " +
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

                    return new LabTestResults(results, isAbnormal);
                }

                return null;
            }
        }
    }
}
