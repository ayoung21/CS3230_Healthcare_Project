using Healthcare_System.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.DAL
{
    static class DoctorDAL
    {
        public static List<Person> GetAllDoctors()
        {
            string query = "SELECT u.user_id, u.first_name, u.last_name, u.address_line1, " +
                "u.address_line2, u.city, u.state, u.zip, u.phone, u.dob, u.gender, d.doctor_id " +
                "FROM user u, doctor d WHERE u.user_id = d.user_id";

            List<Person> matches = new List<Person>();

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

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

                        Person doctor = new Person(userId)
                        {
                            FirstName = (dataReader["first_name"] == DBNull.Value) ? default : Convert.ToString(dataReader["first_name"]),
                            LastName = (dataReader["last_name"] == DBNull.Value) ? default : Convert.ToString(dataReader["last_name"]),
                            Address = address,
                            Phone = (dataReader["phone"] == DBNull.Value) ? default : Convert.ToString(dataReader["phone"]),
                            DateOfBirth = (dataReader["dob"] == DBNull.Value) ? default : Convert.ToDateTime(dataReader["dob"]),
                            Gender = GenderHelper.GenderStringToEnum((dataReader["gender"] == DBNull.Value) ? default : Convert.ToString(dataReader["gender"]))
                        };
                        doctor.AddRole(PersonRoles.Doctor);
                        doctor.DoctorId = (dataReader["doctor_id"] == DBNull.Value) ? default : Convert.ToInt32(dataReader["doctor_id"]);
                        matches.Add(doctor);
                    }

                }

                return matches;
            }
        }
    }
}
