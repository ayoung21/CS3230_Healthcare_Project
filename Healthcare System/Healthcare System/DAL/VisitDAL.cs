using Healthcare_System.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.DAL
{
    /// <summary>
    /// Manages actrions on the visit table.
    /// </summary>
    static class VisitDAL
    {
        /// <summary>Adds the visit.</summary>
        /// <param name="patientId">The patient identifier.</param>
        /// <param name="dateTime">The date time.</param>
        /// <param name="bpSystolic">The bp systolic.</param>
        /// <param name="bpDiastolic">The bp diastolic.</param>
        /// <param name="temperature">The temperature.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="pulse">The pulse.</param>
        /// <param name="symptoms">The symptoms.</param>
        /// <param name="nurseUserId">The nurse user identifier.</param>
        /// <param name="doctorId">The doctor identifier.</param>
        /// <param name="diagnoses">The diagnoses.</param>
        /// <param name="finalDiagnosisMade">if set to <c>true</c> [final diagnosis made].</param>
        /// <returns>true if visit was added, false otherwise</returns>
        public static bool AddVisit(int patientId, DateTime dateTime, int bpSystolic, int bpDiastolic,
            decimal temperature, decimal weight, int pulse, string symptoms, int nurseUserId, int doctorId, 
            string diagnoses, bool finalDiagnosisMade)
        {
            string query = "INSERT INTO visit VALUES(@patient_id, @datetime, @bp_systolic, @bp_diastolic, @temperature, " +
                "@weight, @pulse, @symptoms, @diagnoses, @nurse_user_id, @doctor_id, @final_diagnosis);";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@patient_id", MySqlDbType.Int32);
                cmd.Parameters["@patient_id"].Value = patientId;

                cmd.Parameters.Add("@datetime", MySqlDbType.DateTime);
                cmd.Parameters["@datetime"].Value = dateTime;

                cmd.Parameters.Add("@bp_systolic", MySqlDbType.Int32);
                cmd.Parameters["@bp_systolic"].Value = bpSystolic;

                cmd.Parameters.Add("@bp_diastolic", MySqlDbType.Int32);
                cmd.Parameters["@bp_diastolic"].Value = bpDiastolic;

                cmd.Parameters.Add("@temperature", MySqlDbType.Decimal);
                cmd.Parameters["@temperature"].Value = temperature;

                cmd.Parameters.Add("@weight", MySqlDbType.Decimal);
                cmd.Parameters["@weight"].Value = weight;

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

                cmd.Parameters.Add("@final_diagnosis", MySqlDbType.Int16);
                cmd.Parameters["@final_diagnosis"].Value = finalDiagnosisMade;

                connection.Open();
                int result = cmd.ExecuteNonQuery();

                return result == 1;
            }
        }


        /// <summary>Determines whether [has matching visit] [the specified patient identifier].</summary>
        /// <param name="patientId">The patient identifier.</param>
        /// <param name="appointmentDateTime">The appointment date time.</param>
        /// <returns>
        ///   <c>true</c> if [has matching visit] [the specified patient identifier]; otherwise, <c>false</c>.</returns>
        public static bool HasMatchingVisit(int patientId, DateTime appointmentDateTime)
        {
            string query = "SELECT COUNT(*) FROM visit WHERE patient_id = @patient_id AND datetime = @datetime;";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query.ToString(), connection);

                cmd.Parameters.Add("@patient_id", MySqlDbType.Int32);
                cmd.Parameters["@patient_id"].Value = patientId;

                cmd.Parameters.Add("@datetime", MySqlDbType.DateTime);
                cmd.Parameters["@datetime"].Value = appointmentDateTime;

                connection.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }


        /// <summary>Gets all visits for patient.</summary>
        /// <param name="patientId">The patient identifier.</param>
        /// <returns>List of visits</returns>
        public static List<Visit> GetAllVisitsForPatient(int patientId)
        {
            string query = "SELECT * FROM visit WHERE patient_id = @patient_id;";

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
                        DateTime dateTime = (dataReader["datetime"] == DBNull.Value) ? default : Convert.ToDateTime(dataReader["datetime"]);
                        int bpSystolic = (dataReader["bp_systolic"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["bp_systolic"]);
                        int bpDiastolic = (dataReader["bp_diastolic"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["bp_diastolic"]);
                        decimal temperature = (dataReader["temperature"] == DBNull.Value) ? default : Convert.ToDecimal(dataReader["temperature"]);
                        decimal weight = (dataReader["weight"] == DBNull.Value) ? default : Convert.ToDecimal(dataReader["weight"]);
                        int pulse = (dataReader["pulse"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["pulse"]);
                        string symptoms = (dataReader["symptoms"] == DBNull.Value) ? default : Convert.ToString(dataReader["symptoms"]);
                        string diagnoses = (dataReader["diagnoses"] == DBNull.Value) ? null : Convert.ToString(dataReader["diagnoses"]);
                        int nurseUserId = (dataReader["nurse_user_id"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["nurse_user_id"]);
                        int doctorId = (dataReader["doctor_id"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["doctor_id"]);
                        bool finalDiagnosis = (dataReader["final_diagnosis"] == DBNull.Value) ? false : Convert.ToBoolean(dataReader["final_diagnosis"]);

                        visits.Add(new Visit(patientId, dateTime, bpSystolic, bpDiastolic, temperature, weight, pulse, symptoms, nurseUserId, doctorId, diagnoses, finalDiagnosis));
                    }
                }
            }

            return visits;
        }


        /// <summary>Updates the visit.</summary>
        /// <param name="patientId">The patient identifier.</param>
        /// <param name="datetime">The datetime.</param>
        /// <param name="bpSystolic">The bp systolic.</param>
        /// <param name="bpDiastolic">The bp diastolic.</param>
        /// <param name="temperature">The temperature.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="pulse">The pulse.</param>
        /// <param name="symptoms">The symptoms.</param>
        /// <param name="nurseUserId">The nurse user identifier.</param>
        /// <param name="doctorId">The doctor identifier.</param>
        /// <param name="diagnoses">The diagnoses.</param>
        /// <param name="finalDiagnosisMade">if set to <c>true</c> [final diagnosis made].</param>
        /// <returns>true if visit has been updated, false otherwise</returns>
        public static bool UpdateVisit(int patientId, DateTime datetime, int bpSystolic, int bpDiastolic,
            decimal temperature, decimal weight, int pulse, string symptoms, int nurseUserId, int doctorId, 
            string diagnoses, bool finalDiagnosisMade)
        {
            string query = "UPDATE visit " +
                "SET bp_systolic = @bp_systolic, bp_diastolic = @bp_diastolic, temperature = @temperature, " +
                "weight = @weight, pulse = @pulse, symptoms = @symptoms, diagnoses = @diagnoses, " +
                "nurse_user_id = @nurse_user_id, doctor_id = @doctor_id, final_diagnosis = @final_diagnosis " +
                "WHERE patient_id = @patient_id AND datetime = @datetime;";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@bp_systolic", MySqlDbType.Int32);
                cmd.Parameters["@bp_systolic"].Value = bpSystolic;

                cmd.Parameters.Add("@bp_diastolic", MySqlDbType.Int32);
                cmd.Parameters["@bp_diastolic"].Value = bpDiastolic;

                cmd.Parameters.Add("@temperature", MySqlDbType.Decimal);
                cmd.Parameters["@temperature"].Value = temperature;

                cmd.Parameters.Add("@weight", MySqlDbType.Decimal);
                cmd.Parameters["@weight"].Value = weight;

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

                cmd.Parameters.Add("@final_diagnosis", MySqlDbType.Int16);
                cmd.Parameters["@final_diagnosis"].Value = finalDiagnosisMade;

                connection.Open();
                int result = cmd.ExecuteNonQuery();

                return result == 1;
            }
        }
    }
}
