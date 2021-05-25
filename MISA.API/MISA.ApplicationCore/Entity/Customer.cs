using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entity
{
    /// <summary>
    /// Thông tin khách hàng
    /// </summary>
    /// CreatedBy: LVDat (18/05/2021)
    public class Customer
    {
        /// <summary>
        /// Id khách hàng
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerCode { get; set; }
        /// <summary>
        /// Họ và tên
        /// </summary>
        public string Fullname { get; set; }
        /// <summary>
        /// Giới tinh 0-nữ, 1-nam, 2-khác
        /// </summary>
        public int Gender { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Địa chỉ email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// MÃ nhóm khách hàng
        /// </summary>
        public Guid CustomerGroupId { get; set; }
        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        public string CustomerGroupName { get; set; }
        /// <summary>
        /// Trạng thái
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// MÃ thẻ thành viên
        /// </summary>
        public string MemberCardCode { get; set; }
        /// <summary>
        /// mã số thuế
        /// </summary>
        public string TaxCode { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Tên công ty
        /// </summary>
        public string Company { get; set; }
}

}
