using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    public interface ICustomerGroupService
    {
        ActionServiceResult GetCustomerGroups();
      
        ActionServiceResult GetCustomerGroupById(Guid customerGroupId);
        ActionServiceResult AddCustomerGroup(CustomerGroup customerGroup);
        ActionServiceResult UpdateCustomerGroup(CustomerGroup customerGroup);
        ActionServiceResult DeleteCustomerGroup(Guid customerGroupId);
    }
}
