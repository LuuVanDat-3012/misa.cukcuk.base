using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class CustomerService : ICustomerService

    {
        ICustomerRepository _customerRepository;
        #region Constructor
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion
        #region Method


        public ActionServiceResult AddCustomer(Customer customer)
        {
            return new ActionServiceResult()
            {
                Success = true,
                Message = "Thêm thành công",
                MISAcode = Enumeration.MISAcode.Success,
                data = _customerRepository.AddCustomer(customer)
            };
        }

        public ActionServiceResult DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public ActionServiceResult GetCustomerById(Guid customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            if(customer == null)
            {
                return new ActionServiceResult()
                {
                    Success = true,
                    Message = "Không tìm thấy",
                    MISAcode = Enumeration.MISAcode.Howllow,
                    data = null
                };
            }
            return new ActionServiceResult()
            {
                Success = true,
                Message = "Thành công",
                MISAcode = Enumeration.MISAcode.Success,
                data = customer
            };
        }

        public ActionServiceResult GetCustomers()
        {
            var actionServiceResult = _customerRepository.GetCustomers();
            return new ActionServiceResult()
            {
                Success = true,
                Message = "Tshành công",
                MISAcode = Enumeration.MISAcode.Success,
                data = _customerRepository.GetCustomers()
            };
        }

        public ActionServiceResult UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
