using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
namespace MISA.ApplicationCore.Interface
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: LVDat (20/05/2021)
        List<Customer> GetCustomers();

        /// <summary>
        /// Lấy khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="customerId">MÃ khách hàng</param>
        /// <returns>1 khách hàng</returns>
        /// CreatedBy: LVDat (20/05/2021)
        Customer GetCustomerById(Guid customerId);

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Thông tin thêm mới</param>
        /// <returns>! khách hàng</returns>
        /// CreatedBy: LVDat (20/05/2021)
        int AddCustomer(Customer customer);

        /// <summary>
        /// Sửa thông tin khách hàng
        /// </summary>
        /// <param name="customer">Số bản ghi bị thay đổi</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// CreatedBy: LVDat (20/05/2021)
        int UpdateCustomer(Customer customer);

        /// <summary>
        /// XOá khách hàngtheo ID
        /// </summary>
        /// <param name="customerId">Mã khách gàng cần xoá</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// CreatedBy: LVDat (20/05/2021)
        int DeleteCustomer(Guid customerId);
    }
}
