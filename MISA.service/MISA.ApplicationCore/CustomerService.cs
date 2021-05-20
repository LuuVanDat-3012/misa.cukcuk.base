using MISA.ApplicationCore.Interface;
using MISA.Entity.Model;
using MISA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class CustomerService: ICustomerService

    {
        ICustomerRepository _customerRepository;
        #region Constructor
        CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion
        #region Method

        /// <summary>
        /// Lấy thông tin khách hàng
        /// </summary>
        /// <returns>! danh sách khách hàng</returns>
        public List<Customer> GetCustomerss()
        {
            var customers = _customerRepository.GetCustomers();
            return (List<Customer>)customers;
        }
        /// <summary>
        /// Lấy khách hàng theo ID
        /// </summary>
        /// <param name="id">Id khách hàng</param>
        /// <returns> 1 khách hàng theo id</returns>
        /// CreatedBy : LVDat (19/05/2021)
        public Customer GetCustomerById(Guid id)
        {
            return null;
        }
        /// <summary>
        /// Hàm lọc khách hàng theo mã kh và tên
        /// </summary>
        /// <param name="code">mã khách hàng cần lọc</param>
        /// <param name="name">tên khách hàng cần lọc</param>
        /// <returns> 1 danh sach khách hàng theo mã và tên</returns>
        /// CreatedBy: LVDat (20/05/2021)
        public List<Customer> GetCustomerByCodeAndName(string code, string name)
        {
            return null;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();
            return customers;
        }

        public ActionServiceResult AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public ActionServiceResult UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public ActionServiceResult DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Thêm mới khach hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng cần thêm mới</param>
        /// CreatedBy: LVDat (20/05/2021)


        //Sửa khách hàng theo ID

        //Xoá khách hàng theo ID


        #endregion
    }
}
