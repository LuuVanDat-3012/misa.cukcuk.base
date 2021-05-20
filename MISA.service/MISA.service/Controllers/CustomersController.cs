using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore;
using MISA.ApplicationCore.Interface;
using MISA.Entity.Model;
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
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerService.GetCustomers();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public Customer Get(Guid id)
        {
            return _customerService.GetCustomerById(id);
        }
        /// <summary>
        ///  API trả về 1 danh sách KH theo mã và tên
        /// </summary>
        /// <param name="code">Mã khach hàng cần tìm</param>
        /// <param name="name">Tên cần tìm</param>
        /// <returns> 1 danh sách khách hàng cần tìm</returns>
                //[HttpGet("search")]
                //public List<Customer> GetCustomerByCodeAndName([FromQuery] string code, [FromQuery] string name)
                //{
                //    return customerService.GetCustomerByCodeAndName(code, name);
                //}

                // POST api/<CustomersController>
                //[HttpPost]
                //public int Post([FromBody] Customer customer)
                //{
                //    customerService.InsertCustomer(customer);
                //    return 1;
                //}

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
