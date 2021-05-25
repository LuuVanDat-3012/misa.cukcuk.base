using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    public interface ICustomerService: IBaseService<Customer>
    {
        /// <summary>
        /// Phân trang
        /// </summary>
        /// <param name="limit">số bản ghi</param>
        /// <param name="offser">vị trí trang</param>
        /// <returns>1 danh sách kahchs hàng</returns>
        ActionServiceResult GetCustomerPaging(int limit, int offser);
        /// <summary>
        /// Lấy danh sách khách hàng theo nhom kahchs hàng
        /// </summary>
        /// <param name="customerGroupId">id nhóm khách hàng</param>
        /// <returns>Danh sách khách hàng</returns>
        ActionServiceResult GetCustomerByCustomerGroup(Guid customerGroupId);
    }
}
