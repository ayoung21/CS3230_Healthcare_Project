using MySql.Data.MySqlClient;
using System;
using Healthcare_System.Model;

namespace Healthcare_System.DAL
{
    /// <summary>
    /// Manages actrions on the user table.
    /// </summary>
    static class UserDAL
    {
        /// <summary>
        ///     Registers a new user.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="dob">The dob.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="address1">The address1.</param>
        /// <param name="address2">The address2.</param>
        /// <returns>The generated userId for the new user</returns>
        public static int Register(string firstName, string lastName, string city, string state, 
            int zip, string phone, DateTime dob, Gender gender, string address1, string address2)
        {
            string query = "INSERT INTO user(first_name, last_name, address_line1, address_line2, city, " +
                "state, zip, phone, dob, gender) VALUES(@first_name, @last_name, @address1, @address2, @city, " +
                "@state, @zip, @phone, @dob, @gender); " +
                "SELECT LAST_INSERT_ID();";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

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

                connection.Open();
                object queryResult = cmd.ExecuteScalar();
                int generatedUserId = Convert.ToInt32(queryResult);

                return generatedUserId;
            }
        }

        /// <summary>
        /// Gets the first name of the specified userId.
        /// </summary>
        /// <param name="userId">The userId.</param>
        /// <returns>the first name of the specified userId</returns>
        public static string GetFirstName(int userId)
        {
            string query = "SELECT first_name FROM user WHERE user_id = @userId;";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@userId", MySqlDbType.Int32);
                cmd.Parameters["@userId"].Value = userId;

                connection.Open();

                object queryResult = cmd.ExecuteScalar();
                string firstName = (queryResult == DBNull.Value) ? null : Convert.ToString(queryResult);

                return firstName;
            }
        }

        /// <summary>
        /// Gets the last name of the specified userId.
        /// </summary>
        /// <param name="userId">The userId.</param>
        /// <returns>the last name of the specified userId</returns>
        public static string GetLastName(int userId)
        {
            string query = "SELECT last_name FROM user WHERE user_id = @userId;";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@userId", MySqlDbType.Int32);
                cmd.Parameters["@userId"].Value = userId;

                connection.Open();

                object queryResult = cmd.ExecuteScalar();
                string lastName = (queryResult == DBNull.Value) ? null : Convert.ToString(queryResult);

                return lastName;
            }
        }

        /// <summary>
        ///     Gets the full name (first last) of the specified userId.
        /// </summary>
        /// <param name="userId">The userId.</param>
        /// <returns>the full name name of the specified userId</returns>
        public static string GetFullName(int userId)
        {
            string query = "SELECT first_name, last_name FROM user WHERE user_id = @userId;";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@userId", MySqlDbType.Int32);
                cmd.Parameters["@userId"].Value = userId;

                connection.Open();

                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                string firstName = (dataReader["first_name"] == DBNull.Value) ? null : Convert.ToString(dataReader["first_name"]);
                string lastName = (dataReader["last_name"] == DBNull.Value) ? null : Convert.ToString(dataReader["last_name"]);

                return firstName + " " + lastName;
            }
        }


        /// <summary>Updates the user.</summary>
        /// <param name="person">The person.</param>
        /// <returns>true if user has been updated, false otherwise</returns>
        public static bool UpdateUser(Person person)
        {
            var first_name = person.FirstName;
            var last_name = person.LastName;
            var address_line1 = person.Address.StreetAddress;
            var address_line2 = person.Address.AddressLine2;
            var city = person.Address.City;
            var state = person.Address.State;
            var zip = person.Address.Zip;
            var phone = person.Phone;
            var dob = person.DateOfBirth;
            var gender = person.Gender.ToString();
            var user_id = person.UserId;

            string query = "UPDATE user " +
                "SET first_name = @first_name, last_name = @last_name, address_line1 = @address_line1, address_line2 = @address_line2, city = @city, state = @state, zip = @zip, phone = @phone, dob = @dob, gender = @gender " +
                "WHERE user_id = @user_id;";

            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@first_name", MySqlDbType.VarChar);
                cmd.Parameters["@first_name"].Value = first_name;

                cmd.Parameters.Add("@last_name", MySqlDbType.VarChar);
                cmd.Parameters["@last_name"].Value = last_name;

                cmd.Parameters.Add("@address_line1", MySqlDbType.VarChar);
                cmd.Parameters["@address_line1"].Value = address_line1;

                cmd.Parameters.Add("@address_line2", MySqlDbType.VarChar);
                cmd.Parameters["@address_line2"].Value = address_line2;

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

                cmd.Parameters.Add("@user_id", MySqlDbType.Int32);
                cmd.Parameters["@user_id"].Value = user_id;

                connection.Open();
                int result = cmd.ExecuteNonQuery();
                
                connection.Close();

                return result == 1;
            }
        }
    }
}
