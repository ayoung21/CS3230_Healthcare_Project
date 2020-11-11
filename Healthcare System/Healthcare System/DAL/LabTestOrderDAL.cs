using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.DAL
{
    static class LabTestOrderDAL
    {
        public static int OrderTest(int patientId, DateTime appointmentDateTime)
        {
            string query = "INSERT INTO lab_test_order(patient_id, appointment_datetime) " +
                "VALUES(@patient_id, @appointment_datetime);" +
                "SELET LAST_INSERT_ID();";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@patient_id", MySqlDbType.Int32);
                cmd.Parameters["@patient_id"].Value = patientId;

                cmd.Parameters.Add("@appointment_datetime", MySqlDbType.DateTime);
                cmd.Parameters["@appointment_datetime"].Value = appointmentDateTime;

                connection.Open();
                object queryResult = cmd.ExecuteScalar();
                int generatedOrderId = Convert.ToInt32(queryResult);

                return generatedOrderId;
            }
        }
    }
}
