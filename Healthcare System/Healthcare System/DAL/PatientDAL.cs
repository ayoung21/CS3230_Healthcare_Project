using Healthcare_System.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Healthcare_System.DAL
{
    /// <summary>
    /// Manages actions on the patient table.
    /// </summary>
    class PatientDAL
    {
        public static readonly string tableName = "patient";

        /// <summary>
        ///     Registers a new patient.
        /// </summary>
        /// <param name="userId">The userId in the user table to make a patient account for.</param>
        /// <returns>
        ///     True if successful; false if the userId already exists in the patient table
        ///     or another issue occured
        /// </returns>
        public static bool Register(int userId)
        {
            if (Helpers.IsUserIdInTable(userId, tableName))
            {
                return false;
            }

            string query = $"INSERT INTO {tableName}(user_id) VALUES(@userId);";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@userId", MySqlDbType.Int32);
                cmd.Parameters["@userId"].Value = userId;

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            return Helpers.IsUserIdInTable(userId, tableName);
        }

        public static List<Person> GetSearchResults(string lastName, string firstName, DateTime? dob)
        {
            StringBuilder query = new StringBuilder("SELECT u.user_id, u.first_name, u.last_name, u.address_line1, " +
                "u.address_line2, u.city, u.state, u.zip, u.phone, u.dob, u.gender, p.patient_id " +
                "FROM user u, patient p WHERE u.user_id = p.user_id");

            if (!string.IsNullOrEmpty(lastName))
                query.Append(" AND u.last_name LIKE @lastName");
            if (!string.IsNullOrEmpty(firstName))
                query.Append(" AND u.first_name LIKE @firstName");
            if (dob != null)
                query.Append(" AND dob = @dob");
            query.Append(";");

            List<Person> matches = new List<Person>();

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query.ToString(), connection);

                if (!string.IsNullOrEmpty(lastName))
                {
                    cmd.Parameters.Add("@lastName", MySqlDbType.VarChar);
                    cmd.Parameters["@lastName"].Value = $"%{lastName.Trim()}%";
                }
                if (!string.IsNullOrEmpty(firstName))
                {
                    cmd.Parameters.Add("@firstName", MySqlDbType.VarChar);
                    cmd.Parameters["@firstName"].Value = $"%{firstName.Trim()}%";
                }
                if (dob != null)
                {
                    cmd.Parameters.Add("@dob", MySqlDbType.Date);
                    cmd.Parameters["@dob"].Value = dob;
                }

                connection.Open();

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int userId = (dataReader["user_id"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["user_id"]);
                        Address address = new Address()
                        {
                            StreetAddress = (dataReader["address_line1"] == DBNull.Value) ? default : Convert.ToString(dataReader["address_line1"]),
                            AddressLine2 = (dataReader["address_line2"] == DBNull.Value) ? default : Convert.ToString(dataReader["address_line2"]),
                            City = (dataReader["city"] == DBNull.Value) ? default : Convert.ToString(dataReader["city"]),
                            State = (dataReader["state"] == DBNull.Value) ? default : Convert.ToString(dataReader["state"]),
                            Zip = (dataReader["zip"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["zip"])
                        };

                        Person patient = new Person(userId)
                        {
                            FirstName = (dataReader["first_name"] == DBNull.Value) ? default : Convert.ToString(dataReader["first_name"]),
                            LastName = (dataReader["last_name"] == DBNull.Value) ? default : Convert.ToString(dataReader["last_name"]),
                            Address = address,
                            Phone = (dataReader["phone"] == DBNull.Value) ? default : Convert.ToString(dataReader["phone"]),
                            DateOfBirth = (dataReader["dob"] == DBNull.Value) ? default : Convert.ToDateTime(dataReader["dob"]),
                            Gender = GenderHelper.GenderStringToEnum((dataReader["gender"] == DBNull.Value) ? default : Convert.ToString(dataReader["gender"]))
                        };
                        patient.AddRole(PersonRoles.Patient);
                        patient.PatientID = (dataReader["patient_id"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["patient_id"]);
                        matches.Add(patient);
                    }
                    
                }
                
                connection.Close();

                return matches;
            }
        }

        public static string GetPatientUserId(int patient_id)
        {
            string query = "SELECT user_id FROM patient WHERE patient_id = @patient_id;";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@patient_id", MySqlDbType.Int32);
                cmd.Parameters["@patient_id"].Value = patient_id;

                connection.Open();

                object queryResult = cmd.ExecuteScalar();
                string firstName = (queryResult == DBNull.Value) ? null : Convert.ToString(queryResult);
                connection.Close();

                return firstName;
            }
        }

        public static Person GetPatient(int user_id, int patient_id)
        {
            string query = "SELECT * FROM user WHERE user_id = @user_id;";

            Person result = null;

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@user_id", MySqlDbType.Int32);
                cmd.Parameters["@user_id"].Value = user_id;

                connection.Open();

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {

                    while (dataReader.Read())
                    {

                        int userId = (dataReader["user_id"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["user_id"]);
                        Address address = new Address()
                        {
                            StreetAddress = (dataReader["address_line1"] == DBNull.Value) ? default : Convert.ToString(dataReader["address_line1"]),
                            AddressLine2 = (dataReader["address_line2"] == DBNull.Value) ? default : Convert.ToString(dataReader["address_line2"]),
                            City = (dataReader["city"] == DBNull.Value) ? default : Convert.ToString(dataReader["city"]),
                            State = (dataReader["state"] == DBNull.Value) ? default : Convert.ToString(dataReader["state"]),
                            Zip = (dataReader["zip"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["zip"])
                        };

                        Person patient = new Person(userId)
                        {
                            FirstName = (dataReader["first_name"] == DBNull.Value) ? default : Convert.ToString(dataReader["first_name"]),
                            LastName = (dataReader["last_name"] == DBNull.Value) ? default : Convert.ToString(dataReader["last_name"]),
                            Address = address,
                            Phone = (dataReader["phone"] == DBNull.Value) ? default : Convert.ToString(dataReader["phone"]),
                            DateOfBirth = (dataReader["dob"] == DBNull.Value) ? default : Convert.ToDateTime(dataReader["dob"]),
                            Gender = GenderHelper.GenderStringToEnum((dataReader["gender"] == DBNull.Value) ? default : Convert.ToString(dataReader["gender"]))
                        };
                        patient.AddRole(PersonRoles.Patient);
                        patient.PatientID = patient_id;

                        result = patient;
                    }

                }

            }

            return result;
        }
    }
}
