using MISA.Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(Guid customerId);
        ActionServiceResult AddCustomer(Customer customer);
        ActionServiceResult UpdateCustomer(Customer customer);
        ActionServiceResult DeleteCustomer(Guid customerId);
    }
}
