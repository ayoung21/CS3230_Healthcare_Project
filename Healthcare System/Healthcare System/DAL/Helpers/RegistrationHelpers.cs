using Healthcare_System.DAL.Helpers;
using Healthcare_System.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.DAL
{
    static class RegistrationHelpers
    {

        /// <summary>Registers the administrator.</summary>
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
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>true if admin was registered, false otherwise</returns>
        public static bool RegisterAdministrator(string firstName, string lastName, string city, string state, int zip, 
            string phone, DateTime dob, Gender gender, string address1, string address2, string username, string password)
        {
            MySqlTransaction transaction = TransactionHelpers.BeginTransaction();
            int userId = UserDAL.Register(firstName, lastName, city, state, zip, phone, dob, gender, address1, address2);
            bool accountRegistrationSuccess = AccountDAL.Register(username, password);
            bool administratorRegistrationSuccess = AdministratorDAL.Register(userId, username);
            bool registrationSuccess = accountRegistrationSuccess && administratorRegistrationSuccess;

            return TransactionHelpers.CommitTransaction(transaction) && registrationSuccess;
        }


        /// <summary>Registers the patient.</summary>
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
        /// <returns>true if patient was registerd, false otherwise</returns>
        public static bool RegisterPatient(string firstName, string lastName, string city, string state, int zip,
            string phone, DateTime dob, Gender gender, string address1, string address2)
        {
            MySqlTransaction transaction = TransactionHelpers.BeginTransaction();
            int userId = UserDAL.Register(firstName, lastName, city, state, zip, phone, dob, gender, address1, address2);
            bool registrationSuccess = PatientDAL.Register(userId);

            return TransactionHelpers.CommitTransaction(transaction) && registrationSuccess;
        }
    }
}
