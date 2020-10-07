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
        private static string CONNECTION_STRING = "";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(CONNECTION_STRING);
        }
    }
}
