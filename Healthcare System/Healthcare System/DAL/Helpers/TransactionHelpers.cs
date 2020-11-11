using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.DAL.Helpers
{
    static class TransactionHelpers
    {
        public static MySqlTransaction BeginTransaction()
        {
            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                connection.Open();
                return connection.BeginTransaction();
            }
        }

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
