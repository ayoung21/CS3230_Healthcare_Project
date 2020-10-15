﻿using MySql.Data.MySqlClient;
using System;

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
            int zip, string phone, DateTime dob, string gender, string address1, string address2)
        {
            string query = "INSERT INTO user(first_name, last_name, address_line1, address_line2, city, " +
                "state, zip, phone, dob, gender) VALUES(@first_name, @last_name, @address1, @address2, @city, " +
                "@state, @zip, @phone, @dob, @gender); SELECT LAST_INSERT_ID();";
            //TODO put multiple registrations/insertions into a transaction object and attach it to the connection object
            //before insertion, begin transaction
            //after all insertions, check if any errors occured. If no errors, manually commit operations to DB.
            //if there is an error, just go back (nothing will be done to DB)
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
                int generatedUserId = Convert.ToInt32(queryResult);
                cmd.Connection.Close();

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

        /// <summary>
        /// Gets the last name of the specified userId.
        /// </summary>
        /// <param name="userId">The userId.</param>
        /// <returns>the last name of the specified userId</returns>
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

        /// <summary>
        ///     Gets the full name (first last) of the specified userId.
        /// </summary>
        /// <param name="userId">The userId.</param>
        /// <returns>the full name name of the specified userId</returns>
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
