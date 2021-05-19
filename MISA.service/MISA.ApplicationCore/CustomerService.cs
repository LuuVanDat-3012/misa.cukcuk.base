using MISA.Infrastructure;
using MISA.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class CustomerService
    {
        CustomerContext customerContext = new CustomerContext();
        #region Method

        /// <summary>
        /// Lấy thông tin khách hàng
        /// </summary>
        /// <returns>! danh sách khách hàng</returns>
        public List<Customer> GetCustomers()
        {
            var customers = customerContext.GetCustomers();
            return customers;
        }
        /// <summary>
        /// Lấy khách hàng theo ID
        /// </summary>
        /// <param name="id">Id khách hàng</param>
        /// <returns> 1 khách hàng theo id</returns>
        /// CreatedBy : LVDat (19/05/2021)
        public Customer GetCustomerById(Guid id)
        {
            var customers = customerContext.GetCustomerById(id);
            return customers;
        }
        /// <summary>
        /// Hàm lọc khách hàng theo mã kh và tên
        /// </summary>
        /// <param name="code">mã khách hàng cần lọc</param>
        /// <param name="name">tên khách hàng cần lọc</param>
        /// <returns> 1 danh sach khách hàng theo mã và tên</returns>
        public List<Customer> GetCustomerByCodeAndName(string code, string name)
        {
            return customerContext.GetCustomerByCodeAndName(code, name);
        }
        //Thêm mới khach hàng

        //Sửa khách hàng theo ID

        //Xoá khách hàng theo ID


        #endregion
    }
}
