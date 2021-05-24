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
    public class CustomerGroupRepository : ICustomerGroupRepository
    {
        public IDbConnection _dbConnection;
        #region Constructor
        public CustomerGroupRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultString");
            _dbConnection = new MySqlConnection(connectionString);
        }
        #endregion
        public int AddCustomer(CustomerGroup customerGroup)
        {
            throw new NotImplementedException();
        }

        public int DeleteCustomerGroup(Guid customerGroupId)
        {
            throw new NotImplementedException();
        }

        public CustomerGroup GetCustomerGroupById(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public List<CustomerGroup> GetCustomerGroups()
        {
            return _dbConnection.Query<CustomerGroup>($"Proc_GetCustomerGroups", commandType: CommandType.StoredProcedure).ToList();
        }

        public int UpdateCustomerGroup(CustomerGroup customerGroup)
        {
            throw new NotImplementedException();
        }
    }
}
