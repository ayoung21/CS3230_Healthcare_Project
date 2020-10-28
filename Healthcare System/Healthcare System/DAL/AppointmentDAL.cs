using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.DAL
{
    class AppointmentDAL
    {
        public static void AddAppointment(int patientId, DateTime appointmentDateTime, int doctorId, string reasons)
        {
            string query = "INSERT INTO appointment VALUES(@patient_id, @datetime, @doctor_id, @reasons)";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@patient_id", MySqlDbType.Int32);
                cmd.Parameters["@patient_id"].Value = patientId;

                cmd.Parameters.Add("@datetime", MySqlDbType.DateTime);
                cmd.Parameters["@datetime"].Value = appointmentDateTime;

                cmd.Parameters.Add("@doctor_id", MySqlDbType.Int32);
                cmd.Parameters["@doctor_id"].Value = doctorId;

                cmd.Parameters.Add("@reasons", MySqlDbType.VarChar);
                cmd.Parameters["@reasons"].Value = reasons;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static bool HasMatchingAppointment(DateTime dateTime, int? doctorId = null, int? patientId = null)
        {
            string dateTimeFormat = "%Y-%m-%d %H:%i";
            StringBuilder query = new StringBuilder($"SELECT COUNT(*) FROM appointment WHERE DATE_FORMAT(datetime, '{dateTimeFormat}') = DATE_FORMAT(@datetime, '{dateTimeFormat}')");

            if (doctorId != null)
                query.Append(" AND doctor_id = @doctor_id");

            if (patientId != null)
                query.Append(" AND patient_id = @patient_id");

            query.Append(";");

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query.ToString(), connection);

                cmd.Parameters.Add("@datetime", MySqlDbType.DateTime);
                cmd.Parameters["@datetime"].Value = dateTime;

                if (doctorId != null)
                {
                    cmd.Parameters.Add("@doctor_id", MySqlDbType.Int32);
                    cmd.Parameters["@doctor_id"].Value = doctorId;
                }
                if (patientId != null)
                {
                    cmd.Parameters.Add("@patient_id", MySqlDbType.Int32);
                    cmd.Parameters["@patient_id"].Value = patientId;
                }

                connection.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            
        }
    }
}
