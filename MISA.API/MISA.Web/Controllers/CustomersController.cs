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
        IBaseService<Customer> _baseService;
        public CustomersController(IBaseService<Customer> baseService): base(baseService)
        {
            _baseService = baseService;
        }
    }
}
