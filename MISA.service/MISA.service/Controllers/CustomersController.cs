using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.service.Data;
using MISA.service.Model;
using MISA.service.Service;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        
        // GET: api/<CustomersController>
        [HttpGet]
        public List<Customer> Get()
        {
            List<Customer> customers = new List<Customer>();
            string connectionString = "Host = localhost; Port = 3306;Database = lvdat_misa_cukcuk; User Id = root ;Password = lovanmet1;Character Set=utf8";
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                //Lấy dữ liệu
                customers = db.Query<Customer>($"Proc_GetCustomers", commandType: CommandType.StoredProcedure).ToList();
            }
            return customers;
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ActionServiceResult Get(Guid id)
        {

            Customer customer = new Customer();
            string connectionString = "Host = localhost; Port = 3306;Database = lvdat_misa_cukcuk; User Id = root ;Password = lovanmet1;Character Set=utf8";
            
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                //Lấy dữ liệu
                var sql = $"Select * From Customer where customerId = '{id.ToString()}'";
                customer = db.Query<Customer>(sql).FirstOrDefault();
            }
         
            return new ActionServiceResult()
            {
                Message = "Thanh cong",
                MISAcode = Enumeration.MISAcode.Success,
                Success = true,
                data = customer
            };
        }

        // POST api/<CustomersController>
        [HttpPost]
        public int Post([FromBody] Customer customer)
        {
            var sqlQuery = $"INSERT INTO customer(CustomerId, CustomerCode, Fullname, Phone) VALUES(" +
                $"'{Guid.NewGuid().ToString()}'," +
                $"'{customer.CustomerCode.ToString()}'," +
                $"'{customer.Fullname.ToString()}'," +
                $"'{customer.Phone.ToString()}')";
            DAL.GetConnection().Execute(sqlQuery);
            return 1;
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
