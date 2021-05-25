using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using MISA.ApplicationCore.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class CustomerService : BaseService<Customer>, ICustomerService

    {
        IBaseRepository<Customer> _baseRepository;
        #region Constructor
        public CustomerService(IBaseRepository<Customer> baseRepository): base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public ActionServiceResult GetCustomerByCustomerGroup(Guid groupId)
        {
            throw new NotImplementedException();
        }

        public ActionServiceResult GetCustomerPaging(int limit, int offser)
        {
            throw new NotImplementedException();
        }


        #endregion
        #region Method



        #endregion
    }
}
