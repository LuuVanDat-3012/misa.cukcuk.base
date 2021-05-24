using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    public interface ICustomerGroupRepository
    {
        
        List<CustomerGroup> GetCustomerGroups();

        
        CustomerGroup GetCustomerGroupById(Guid customerId);

       
        int AddCustomer(CustomerGroup customerGroup);

       
        int UpdateCustomerGroup(CustomerGroup customerGroup);

        
        int DeleteCustomerGroup(Guid customerGroupId);
    }
}
