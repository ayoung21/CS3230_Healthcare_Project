using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare_System.Data_Access_Layer;
using MySql.Data.MySqlClient;

namespace Healthcare_System.DAL
{
    public static class DbConnection
    {
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(Configuration.CONNECTION_STRING);
        }
    }
}
