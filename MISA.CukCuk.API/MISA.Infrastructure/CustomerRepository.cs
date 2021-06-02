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
    public class CustomerRepository :BaseRepository<Customer>, ICustomerRepository
    {

        
        #region Constructor
        public CustomerRepository(IConfiguration configuration):base(configuration)
        {
           
        }
        #endregion

        #region Method
      
        public Customer GetCustomerByCode(string customerCode)
        {
            var customer = _dbConnection.Query<Customer>($"Proc_GetCustomerByCode", new { customerCode = customerCode }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return customer;
        }
     
        public List<Customer> GetCustomerByName(string name)
        {
            List<Customer> customers = _dbConnection.Query<Customer>($"Proc_GetCustomerByName", new { Fullname = name }, commandType: CommandType.StoredProcedure).ToList();
            return customers;
        }

        public int DeleteMultipleCustomer(Guid[] listCustomerId)
        {
            string combindedString = string.Join(",", listCustomerId.ToArray());
            return _dbConnection.Execute($"Proc_DeleteCustomer", new { id = combindedString }, commandType: CommandType.StoredProcedure);
        }
        #endregion
    }
}
