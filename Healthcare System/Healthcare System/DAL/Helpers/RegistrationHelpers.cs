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
