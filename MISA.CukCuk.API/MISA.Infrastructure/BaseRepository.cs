using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interface;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        protected IDbConnection _dbConnection;
        protected string _tableName;
        string _connectionString = string.Empty;
        IConfiguration _configuration;
        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
             _connectionString = configuration.GetConnectionString("DefaultString");
            _dbConnection = new MySqlConnection(_connectionString);
            _tableName = typeof(TEntity).Name;
        }
        #endregion

        public int AddEntity(TEntity entity)
        {
            // Xử lí kiểu dữ liệu
            var param = MappingDataType<TEntity>(entity);
            // Viết commandText
            var result = _dbConnection.Execute($"Proc_Add{_tableName}", param, commandType: CommandType.StoredProcedure);
            return result;
        }

        public int DeleteEntity(Guid entityId)
        {
            var result = _dbConnection.Execute($"Proc_Delete{_tableName}", new { Id = entityId.ToString() }, commandType: CommandType.StoredProcedure);
            return result;
        }

        public TEntity GetEntityById(Guid entityId)
        {
            var entity = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}ById", new { Id = entityId.ToString() }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }

        public List<TEntity> GetEntities()
        {
            var entities = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}", commandType: CommandType.StoredProcedure).ToList();
            //Trả về dữ kiệu
            return entities;
        }

        public int UpdateEntity(TEntity entity)
        {
            var param = MappingDataType<TEntity>(entity);
            var result = _dbConnection.Execute($"Proc_Update{_tableName}",param, commandType: CommandType.StoredProcedure);
            //Trả về dữ kiệu
            return result;
        }
        private DynamicParameters MappingDataType<TEntity>(TEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            var param = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    param.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    param.Add($"@{propertyName}", propertyValue);
                }
            }
            return param;
        }

        public TEntity GetEntityByProperty(string propertyName, object propertyValue)
        {
            var query = $"select * from {_tableName} where {propertyName} = '{propertyValue}'";
            var entity = _dbConnection.Query<TEntity>(query, commandType: CommandType.Text).FirstOrDefault();
            return entity;
        }
    }
}
