using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Service
{
    public class CustomerGroupService : ICustomerGroupService
    {
        ICustomerGroupRepository _customerGroupRepository;
        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }
        public ActionServiceResult AddCustomerGroup(CustomerGroup customerGroup)
        {
            throw new NotImplementedException();
        }

        public ActionServiceResult DeleteCustomerGroup(Guid customerGroupId)
        {
            throw new NotImplementedException();
        }

        public ActionServiceResult GetCustomerGroupById(Guid customerGroupId)
        {
            throw new NotImplementedException();
        }

        public ActionServiceResult GetCustomerGroups()
        {
            return new ActionServiceResult()
            {
                Success = true,
                Message = "Thành công",
                MISAcode = Enumeration.MISAcode.Success,
                data = _customerGroupRepository.GetCustomerGroups()
            };

        }

        public ActionServiceResult UpdateCustomerGroup(CustomerGroup customerGroup)
        {
            throw new NotImplementedException();
        }
    }
}
