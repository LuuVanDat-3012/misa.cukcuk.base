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
        /// CreatedBy: LVDat (26/5/2021)
        ActionServiceResult GetCustomerPaging(int limit, int offser);
        /// <summary>
        /// Lấy danh sách khách hàng theo nhom kahchs hàng
        /// </summary>
        /// <param name="customerGroupId">id nhóm khách hàng</param>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: LVDat (26/5/2021)
        ActionServiceResult GetCustomerByCustomerGroup(Guid customerGroupId);
        /// <summary>
        /// Lấy dánh sách khách hàng theo tên
        /// </summary>
        /// <param name="name">tên khách hàng</param>
        /// <returns>1 danh sách khãhs hàng</returns>
        /// CreatedBy: LVDat (26/5/2021)
        ActionServiceResult GetCustomerByName(string name);
        /// <summary>
        /// Xoá danh sách khách hàng
        /// </summary>
        /// <param name="guids">danh sách id cần xoá</param>
        /// <returns>số dòng ảnh hưởng</returns>
        /// CreatedBy: LVDat (26/5/2021)
        ActionServiceResult DeleteMultiple(Guid[] guids);
    }
}
