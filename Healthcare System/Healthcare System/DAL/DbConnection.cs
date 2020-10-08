using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Healthcare_System.DAL
{
    public static class DbConnection
    {
        private static string username = "";
        private static string password = "";
        private static string ipAddress = "";
        private static string CONNECTION_STRING = $"server={ipAddress}; port=3306; uid={username}; pwd={password};database={username};";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(CONNECTION_STRING);
        }
    }
}
