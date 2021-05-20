using Dapper;
using MISA.Entity.Model;
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
        public int AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var connectionString = "Host = localhost; Port = 3306;Database = lvdat_misa_cukcuk; User Id = root ;Password = lovanmet1;Character Set=utf8";
            var dbConnection = new MySqlConnection(connectionString);
            var customers = dbConnection.Query<Customer>($"Proc_GetCustomers", commandType: CommandType.StoredProcedure).ToList();
            //    //Trả về dữ kiệu
            return customers;
        }

        public int UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
