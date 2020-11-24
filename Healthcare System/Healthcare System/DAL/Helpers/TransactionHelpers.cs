using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.DAL.Helpers
{
    /// <summary>
    /// Helpers for using transactions in queries
    /// </summary>
    static class TransactionHelpers
    {

        /// <summary>Begins the transaction.</summary>
        /// <returns>My SQL Transaction</returns>
        public static MySqlTransaction BeginTransaction()
        {
            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                connection.Open();
                return connection.BeginTransaction();
            }
        }


        /// <summary>Commits the transaction.</summary>
        /// <param name="transaction">The transaction.</param>
        /// <returns>true if transaction has been committed, false otherwise</returns>
        public static bool CommitTransaction(MySqlTransaction transaction)
        {
            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                connection.Open();
                try
                {
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }

            return true;
        }
    }
}
