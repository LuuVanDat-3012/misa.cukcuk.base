using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
namespace MISA.ApplicationCore.Interface
{
    public interface ICustomerRepository: IBaseRepository<Customer>
    {
        /// <summary>
        /// Lấy 1 khách hàng theo mã
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns>1 khách hàng</returns>
        /// CreatedBy: LVDat (29/05/2021)
        public Customer GetCustomerByCode(String customerCode);
        /// <summary>
        /// Lấy danh sách khách hàng theo tên
        /// </summary>
        /// <param name="name">tên cần tìm kiếm</param>
        /// <returns>1 dánh sách khách hàng</returns>
        public List<Customer> GetCustomerByName(string name);

        public int DeleteMultipleCustomer(Guid[] guids);
    }
}
