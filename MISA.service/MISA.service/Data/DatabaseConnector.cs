using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.service.Data
{
    public class DatabaseConnector<TEntity>
    {
        static string connectionString = "Host = localhost; Port = 3306;Database = lvdat_misa_cukcuk; User Id = root ;Password = lovanmet1;Character Set=utf8";
                            
        string className = typeof(TEntity).Name;
        IDbConnection _bConnection;

        public DatabaseConnector()
        {
            _bConnection = new MySqlConnection(connectionString);
        }
        public IEnumerable<TEntity> GetAll()
        {
            var sql = $"select * from {className} limit 50";
            var data = _bConnection.Query<TEntity>(sql).ToList();
            return data;
        }
    }
}
