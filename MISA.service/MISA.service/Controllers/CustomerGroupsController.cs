using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.service.Model;
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
    public class CustomerGroupsController : ControllerBase
    {
        // GET: api/<CustomerGroupsController>
        [HttpGet]
        public List<CustomerGroup> Get()
        {
            List<CustomerGroup> customerGroups = new List<CustomerGroup>();
            string connectionString = "Host = localhost; Port = 3306;Database = lvdat_misa_cukcuk; User Id = root ;Password = lovanmet1;Character Set=utf8";
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                //Lấy dữ liệu
                customerGroups = db.Query<CustomerGroup>("Select * From CustomerGroup").ToList();
            }
            return customerGroups;
        }

        // GET api/<CustomerGroupsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerGroupsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerGroupsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerGroupsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
