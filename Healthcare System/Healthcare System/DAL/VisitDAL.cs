﻿using Healthcare_System.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.DAL
{
    class VisitDAL
    {
        public static bool AddVisit(int patientId, DateTime dateTime, int bpSystolic, int bpDiastolic,
            decimal temperature, int pulse, string symptoms, int nurseUserId, int doctorId, string diagnoses)
        {
            string query = "INSERT INTO record VALUES(@patient_id, @appt_datetime, @bp_systolic, @bp_diastolic, @temperature, " +
                "@pulse, @symptoms, @diagnoses, @nurse_user_id, @doctor_id);";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@patient_id", MySqlDbType.Int32);
                cmd.Parameters["@patient_id"].Value = patientId;

                cmd.Parameters.Add("@appt_datetime", MySqlDbType.DateTime);
                cmd.Parameters["@appt_datetime"].Value = dateTime;

                cmd.Parameters.Add("@bp_systolic", MySqlDbType.Int32);
                cmd.Parameters["@bp_systolic"].Value = bpSystolic;

                cmd.Parameters.Add("@bp_diastolic", MySqlDbType.Int32);
                cmd.Parameters["@bp_diastolic"].Value = bpDiastolic;

                cmd.Parameters.Add("@temperature", MySqlDbType.Decimal);
                cmd.Parameters["@temperature"].Value = temperature;

                cmd.Parameters.Add("@pulse", MySqlDbType.Int32);
                cmd.Parameters["@pulse"].Value = pulse;

                cmd.Parameters.Add("@symptoms", MySqlDbType.VarChar);
                cmd.Parameters["@symptoms"].Value = symptoms;

                cmd.Parameters.Add("@diagnoses", MySqlDbType.VarChar);
                cmd.Parameters["@diagnoses"].Value = diagnoses;

                cmd.Parameters.Add("@nurse_user_id", MySqlDbType.Int32);
                cmd.Parameters["@nurse_user_id"].Value = nurseUserId;

                cmd.Parameters.Add("@doctor_id", MySqlDbType.Int32);
                cmd.Parameters["@doctor_id"].Value = doctorId;

                connection.Open();
                int result = cmd.ExecuteNonQuery();

                return result == 1;
            }
        }

        public static bool HasMatchingVisit(int patientId, DateTime appointmentDateTime)
        {
            string query = "SELECT COUNT(*) FROM record WHERE patient_id = @patient_id AND appointment_datetime = @appointment_datetime;";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query.ToString(), connection);

                cmd.Parameters.Add("@patient_id", MySqlDbType.Int32);
                cmd.Parameters["@patient_id"].Value = patientId;

                cmd.Parameters.Add("@appointment_datetime", MySqlDbType.DateTime);
                cmd.Parameters["@appointment_datetime"].Value = appointmentDateTime;

                connection.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public static List<Visit> GetAllVisitsForPatient(int patientId)
        {
            string query = "SELECT * FROM record WHERE patient_id = @patient_id;";

            List<Visit> visits = new List<Visit>();

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
                        DateTime dateTime = (dataReader["appointment_datetime"] == DBNull.Value) ? default : Convert.ToDateTime(dataReader["appointment_datetime"]);
                        int bpSystolic = (dataReader["bp_systolic"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["bp_systolic"]);
                        int bpDiastolic = (dataReader["bp_diastolic"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["bp_diastolic"]);
                        decimal temperature = (dataReader["temperature"] == DBNull.Value) ? default : Convert.ToDecimal(dataReader["temperature"]);
                        int pulse = (dataReader["pulse"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["pulse"]);
                        string symptoms = (dataReader["symptoms"] == DBNull.Value) ? default : Convert.ToString(dataReader["symptoms"]);
                        string diagnoses = (dataReader["diagnoses"] == DBNull.Value) ? null : Convert.ToString(dataReader["diagnoses"]);
                        int nurseUserId = (dataReader["nurse_user_id"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["nurse_user_id"]);
                        int doctorId = (dataReader["doctor_id"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["doctor_id"]);

                        visits.Add(new Visit(patientId, dateTime, bpSystolic, bpDiastolic, temperature, pulse, symptoms, nurseUserId, doctorId, diagnoses));
                    }
                }
            }

            return visits;
        }

        public static bool UpdateVisit(int patientId, DateTime datetime, int bpSystolic, int bpDiastolic,
            decimal temperature, int pulse, string symptoms, int nurseUserId, int doctorId, string diagnoses)
        {
            string query = "UPDATE record " +
                "SET bp_systolic = @bp_systolic, bp_diastolic = @bp_diastolic, temperature = @temperature, pulse = @pulse, " +
                "symptoms = @symptoms, diagnoses = @diagnoses, nurse_user_id = @nurse_user_id, doctor_id = @doctor_id " +
                "WHERE patient_id = @patient_id AND appointment_datetime = @datetime;";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@bp_systolic", MySqlDbType.Int32);
                cmd.Parameters["@bp_systolic"].Value = bpSystolic;

                cmd.Parameters.Add("@bp_diastolic", MySqlDbType.Int32);
                cmd.Parameters["@bp_diastolic"].Value = bpDiastolic;

                cmd.Parameters.Add("@temperature", MySqlDbType.Decimal);
                cmd.Parameters["@temperature"].Value = temperature;

                cmd.Parameters.Add("@pulse", MySqlDbType.Int32);
                cmd.Parameters["@pulse"].Value = pulse;

                cmd.Parameters.Add("@symptoms", MySqlDbType.VarChar);
                cmd.Parameters["@symptoms"].Value = symptoms;

                cmd.Parameters.Add("@diagnoses", MySqlDbType.VarChar);
                cmd.Parameters["@diagnoses"].Value = diagnoses;

                cmd.Parameters.Add("@nurse_user_id", MySqlDbType.Int32);
                cmd.Parameters["@nurse_user_id"].Value = nurseUserId;

                cmd.Parameters.Add("@doctor_id", MySqlDbType.Int32);
                cmd.Parameters["@doctor_id"].Value = doctorId;

                cmd.Parameters.Add("@patient_id", MySqlDbType.Int32);
                cmd.Parameters["@patient_id"].Value = patientId;

                cmd.Parameters.Add("@datetime", MySqlDbType.DateTime);
                cmd.Parameters["@datetime"].Value = datetime;

                connection.Open();
                int result = cmd.ExecuteNonQuery();

                return result == 1;
            }
        }
    }
}