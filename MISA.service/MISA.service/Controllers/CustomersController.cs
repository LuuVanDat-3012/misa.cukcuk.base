using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore;
using MISA.Infrastructure.Model;
using MISA.service.Data;
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
        public string connectionString;
        CustomerService customerService = new CustomerService();


        // GET: api/<CustomersController>
        [HttpGet]
        public List<Customer> Get()
        {
            
            return customerService.GetCustomers();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public Customer Get(Guid id)
        {
            return customerService.GetCustomerById(id);
        }
        /// <summary>
        ///  API trả về 1 danh sách KH theo mã và tên
        /// </summary>
        /// <param name="code">Mã khach hàng cần tìm</param>
        /// <param name="name">Tên cần tìm</param>
        /// <returns> 1 danh sách khách hàng cần tìm</returns>
        [HttpGet("search")]
        public List<Customer> GetCustomerByCodeAndName([FromQuery] string code, [FromQuery] string name)
        {
            return customerService.GetCustomerByCodeAndName(code, name);
        }


        // POST api/<CustomersController>
        [HttpPost]
        public int Post([FromBody] Customer customer)
        {
            var sqlQuery = $"INSERT INTO customer(CustomerId, CustomerCode, Fullname, Phone, CreatedBy, CreatedDate, ModifiedBy) VALUES(" +
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
