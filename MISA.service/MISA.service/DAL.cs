using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.service
{
    public class DAL
    {
        public static string connectionString = "Host = 127.0.0.1;" +
                           "Port = 3306; " +
                           "Database = lvdat_misa_cukcuk;" +
                           "User Id = root;" +
                           "Password = lovanmet1;" +
                           "Character Set=utf8";
        public static MySqlConnection GetConnection()
        {
            MySqlConnection dbConnection = new MySqlConnection(connectionString);
            return dbConnection;
        }
        

    }
}
