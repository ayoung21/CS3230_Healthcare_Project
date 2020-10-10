using MySql.Data.MySqlClient;
using System;

namespace Healthcare_System.DAL
{
    static class UserDAL
    {
        public static int Register(string firstName, string lastName, string city, string state, 
            int zip, string phone, DateTime dob, string gender, string address1, string address2)
        {
            string query = "INSERT INTO user(first_name, last_name, address_line1, address_line2, city, " +
                "state, zip, phone, dob, gender) VALUES(@first_name, @last_name, @address1, @address2, @city, " +
                "@state, @zip, @phone, @dob, @gender); SELECT LAST_INSERT_ID();";

            using (MySqlCommand cmd = new MySqlCommand(query, DbConnection.GetConnection()))
            {
                cmd.Parameters.Add("@first_name", MySqlDbType.VarChar);
                cmd.Parameters["@first_name"].Value = firstName;

                cmd.Parameters.Add("@last_name", MySqlDbType.VarChar);
                cmd.Parameters["@last_name"].Value = lastName;

                cmd.Parameters.Add("@address1", MySqlDbType.VarChar);
                cmd.Parameters["@address1"].Value = address1;

                cmd.Parameters.Add("@address2", MySqlDbType.VarChar);
                cmd.Parameters["@address2"].Value = address2;

                cmd.Parameters.Add("@city", MySqlDbType.VarChar);
                cmd.Parameters["@city"].Value = city;

                cmd.Parameters.Add("@state", MySqlDbType.VarChar);
                cmd.Parameters["@state"].Value = state;

                cmd.Parameters.Add("@zip", MySqlDbType.Int32);
                cmd.Parameters["@zip"].Value = zip;

                cmd.Parameters.Add("@phone", MySqlDbType.VarChar);
                cmd.Parameters["@phone"].Value = phone;

                cmd.Parameters.Add("@dob", MySqlDbType.Date);
                cmd.Parameters["@dob"].Value = dob;

                cmd.Parameters.Add("@gender", MySqlDbType.VarChar);
                cmd.Parameters["@gender"].Value = gender;

                cmd.Connection = DbConnection.GetConnection();

                cmd.Connection.Open();
                object queryResult = cmd.ExecuteScalar();
                int generatedPk = Convert.ToInt32(queryResult);
                cmd.Connection.Close();

                return generatedPk;
            }
        }

        public static string GetFirstName(int userId)
        {
            string query = "SELECT first_name FROM user WHERE user_id = @userId;";

            using (MySqlCommand cmd = new MySqlCommand(query, DbConnection.GetConnection()))
            {
                cmd.Parameters.Add("@userId", MySqlDbType.Int32);
                cmd.Parameters["@userId"].Value = userId;

                cmd.Connection = DbConnection.GetConnection();

                cmd.Connection.Open();

                object queryResult = cmd.ExecuteScalar();
                string firstName = (queryResult == DBNull.Value) ? null : Convert.ToString(queryResult);
                cmd.Connection.Close();

                return firstName;
            }
        }

        public static string GetLastName(int userId)
        {
            string query = "SELECT last_name FROM user WHERE user_id = @userId;";

            using (MySqlCommand cmd = new MySqlCommand(query, DbConnection.GetConnection()))
            {
                cmd.Parameters.Add("@userId", MySqlDbType.Int32);
                cmd.Parameters["@userId"].Value = userId;

                cmd.Connection = DbConnection.GetConnection();

                cmd.Connection.Open();

                object queryResult = cmd.ExecuteScalar();
                string lastName = (queryResult == DBNull.Value) ? null : Convert.ToString(queryResult);
                cmd.Connection.Close();

                return lastName;
            }
        }

        public static string GetFullName(int userId)
        {
            string query = "SELECT first_name, last_name FROM user WHERE user_id = @userId;";

            using (MySqlCommand cmd = new MySqlCommand(query, DbConnection.GetConnection()))
            {
                cmd.Parameters.Add("@userId", MySqlDbType.Int32);
                cmd.Parameters["@userId"].Value = userId;

                cmd.Connection = DbConnection.GetConnection();

                cmd.Connection.Open();

                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                string firstName = (dataReader["first_name"] == DBNull.Value) ? null : Convert.ToString(dataReader["first_name"]);
                string lastName = (dataReader["last_name"] == DBNull.Value) ? null : Convert.ToString(dataReader["last_name"]);
                cmd.Connection.Close();

                return firstName + " " + lastName;
            }
        }
    }
}
