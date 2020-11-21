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
    /// Manages actions on related to lab tests order table.
    /// </summary>
    static class LabTestOrderDAL
    {

        /// <summary>Orders the test.</summary>
        /// <param name="patientId">The patient identifier.</param>
        /// <param name="visitDateTime">The visit date time.</param>
        /// <returns>Order id</returns>
        public static int OrderTest(int patientId, DateTime visitDateTime)
        {
            string query = "INSERT INTO lab_test_order(patient_id, visit_datetime) " +
                "VALUES(@patient_id, @visit_datetime);" +
                "SELECT LAST_INSERT_ID();";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@patient_id", MySqlDbType.Int32);
                cmd.Parameters["@patient_id"].Value = patientId;

                cmd.Parameters.Add("@visit_datetime", MySqlDbType.DateTime);
                cmd.Parameters["@visit_datetime"].Value = visitDateTime;

                connection.Open();
                object queryResult = cmd.ExecuteScalar();
                int generatedOrderId = Convert.ToInt32(queryResult);

                return generatedOrderId;
            }
        }


        /// <summary>Determines whether [has test order] [the specified patient identifier].</summary>
        /// <param name="patientId">The patient identifier.</param>
        /// <param name="visitDateTime">The visit date time.</param>
        /// <returns>
        ///   <c>true</c> if [has test order] [the specified patient identifier]; otherwise, <c>false</c>.</returns>
        public static bool HasTestOrder(int patientId, DateTime visitDateTime)
        {
            string query = "SELECT COUNT(*) FROM lab_test_order " +
                "WHERE patient_id = @patient_id AND visit_datetime = @visit_datetime;";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@patient_id", MySqlDbType.Int32);
                cmd.Parameters["@patient_id"].Value = patientId;

                cmd.Parameters.Add("@visit_datetime", MySqlDbType.DateTime);
                cmd.Parameters["@visit_datetime"].Value = visitDateTime;

                connection.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }


        /// <summary>Gets the test order.</summary>
        /// <param name="patientId">The patient identifier.</param>
        /// <param name="visitDateTime">The visit date time.</param>
        /// <returns>Lab test order</returns>
        public static LabTestOrder GetTestOrder(int patientId, DateTime visitDateTime)
        {
            string query = "SELECT order_id FROM lab_test_order " +
                "WHERE patient_id = @patient_id AND visit_datetime = @visit_datetime;";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@patient_id", MySqlDbType.Int32);
                cmd.Parameters["@patient_id"].Value = patientId;

                cmd.Parameters.Add("@visit_datetime", MySqlDbType.DateTime);
                cmd.Parameters["@visit_datetime"].Value = visitDateTime;

                connection.Open();
                object queryResult = cmd.ExecuteScalar();

                if (queryResult == null)
                {
                    return null;
                }

                int orderId = (queryResult == DBNull.Value) ? default : Convert.ToInt32(queryResult);

                return new LabTestOrder(orderId, patientId, visitDateTime);
            }
        }
    }
}
