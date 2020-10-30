using Healthcare_System.Model;
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
        public static bool AddAppointment(int patientId, DateTime appointmentDateTime, int doctorId, string reasons)
        {
            string query = "INSERT INTO appointment VALUES(@patient_id, @datetime, @doctor_id, @reasons);";

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
                int result = cmd.ExecuteNonQuery();

                return result == 1;
            }
        }

        public static bool UpdateAppointment(int patientId, DateTime oldDateTime, DateTime newDateTime, int doctorId, string reasons)
        {
            string query = "UPDATE appointment " +
                "SET datetime = @new_datetime, doctor_id = @doctor_id, reasons = @reasons " +
                "WHERE patient_id = @patient_id AND datetime = @old_datetime";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@patient_id", MySqlDbType.Int32);
                cmd.Parameters["@patient_id"].Value = patientId;

                cmd.Parameters.Add("@old_datetime", MySqlDbType.DateTime);
                cmd.Parameters["@old_datetime"].Value = oldDateTime;

                cmd.Parameters.Add("@new_datetime", MySqlDbType.DateTime);
                cmd.Parameters["@new_datetime"].Value = newDateTime;

                cmd.Parameters.Add("@doctor_id", MySqlDbType.Int32);
                cmd.Parameters["@doctor_id"].Value = doctorId;

                cmd.Parameters.Add("@reasons", MySqlDbType.VarChar);
                cmd.Parameters["@reasons"].Value = reasons;

                connection.Open();
                int result = cmd.ExecuteNonQuery();

                return result == 1;
            }
        }

        public static bool HasMatchingAppointment(DateTime dateTime, int? doctorId = null, int? patientId = null, Appointment ignoredAppointment = null)
        {
            string dateTimeFormat = "%Y-%m-%d %H:%i";
            StringBuilder query = new StringBuilder($"SELECT COUNT(*) FROM appointment WHERE DATE_FORMAT(datetime, '{dateTimeFormat}') = DATE_FORMAT(@datetime, '{dateTimeFormat}')");

            if (doctorId != null)
                query.Append(" AND doctor_id = @doctor_id");

            if (patientId != null)
                query.Append(" AND patient_id = @patient_id");

            if (ignoredAppointment != null)
                query.Append(" AND NOT(patient_id = @ignored_patient_id AND datetime = @ignored_datetime)");

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
                if (ignoredAppointment != null)
                {
                    cmd.Parameters.Add("@ignored_patient_id", MySqlDbType.Int32);
                    cmd.Parameters["@ignored_patient_id"].Value = ignoredAppointment.PatientId;

                    cmd.Parameters.Add("@ignored_datetime", MySqlDbType.DateTime);
                    cmd.Parameters["@ignored_datetime"].Value = ignoredAppointment.DateTime;
                }

                connection.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            
        }

        public static List<Appointment> GetAllAppointmentsForPatient(int patientId)
        {
            string query = "SELECT * FROM appointment WHERE patient_id = @patient_id;";

            List<Appointment> appointments = new List<Appointment>();

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@patient_id", MySqlDbType.Int32);
                cmd.Parameters["@patient_id"].Value = patientId;

                connection.Open();

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DateTime dateTime = (dataReader["datetime"] == DBNull.Value) ? default : Convert.ToDateTime(dataReader["datetime"]);
                        int doctorId = (dataReader["doctor_id"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["doctor_id"]);
                        string reasons = (dataReader["reasons"] == DBNull.Value) ? default : Convert.ToString(dataReader["reasons"]);

                        appointments.Add(new Appointment(patientId, dateTime, doctorId, reasons));
                    }
                }
            }

            return appointments;
        }
    }
}
