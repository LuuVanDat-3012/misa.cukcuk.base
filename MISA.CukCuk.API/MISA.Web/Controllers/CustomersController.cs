using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Web.Controllers
{
    public class CustomersController: BaseEntitiesController<Customer>
    {
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService) : base(customerService)
        {
            _customerService = customerService;
        }
        /// <summary>
        /// Tìm kiếm theo tên khách hàng
        /// </summary>
        /// <param name="name">Tên khách hàng</param>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: LVDat (30/05/2021)
        [HttpGet("search/{name}")]
        public IActionResult GetCustomersByName(string name)
        {
            var result = _customerService.GetCustomerByName(name);
            return Ok(result);
        }
        [HttpDelete("multiple")]
        public IActionResult DeleteMultiple([FromBody] Guid[] guids)
        {
            var result = _customerService.DeleteMultiple(guids);
            return Ok(result);
        }
    }
    

}
