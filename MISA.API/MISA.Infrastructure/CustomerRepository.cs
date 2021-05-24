using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {

        public IDbConnection _dbConnection;
        #region Constructor
        public CustomerRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultString");
            _dbConnection = new MySqlConnection(connectionString);
        }
        #endregion

        #region Method
        public int AddCustomer(Customer customer)
        {
            // Xử lí kiểu dữ liệu
            var param = MappingDataType<Customer>(customer);
            // Viết commandText
            var result = _dbConnection.Execute($"Proc_AddCustomer", param, commandType: CommandType.StoredProcedure);
            return result;
        }

        public int DeleteCustomer(Guid customerId)
        {
            var result = _dbConnection.Execute($"Proc_AddCustomer", commandType: CommandType.StoredProcedure);
            return result;
        }

        public Customer GetCustomerById(Guid customerId)
        {
                var customers = _dbConnection.Query<Customer>($"Proc_GetCustomerById", new { customerId = customerId.ToString() }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return customers;
        }

        public List<Customer> GetCustomers()
        {
            var customers = _dbConnection.Query<Customer>($"Proc_GetCustomers", commandType: CommandType.StoredProcedure).ToList();
            //Trả về dữ kiệu
            return customers;
        }

        public int UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
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
        #endregion
    }
}
