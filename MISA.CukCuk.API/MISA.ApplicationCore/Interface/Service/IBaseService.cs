using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    public interface IBaseService<TEntity>
    {
       /// <summary>
       /// Phân trang đối tượng
       /// </summary>
       /// <param name="limit">Vị trí bắt đầu lấy</param>
       /// <param name="offset">Số bản ghi muốn lấy</param>
       /// <param name="propertySearch">Thông tin tìm kiếm</param>
       /// <returns></returns>
        ActionServiceResult GetEntities(int page, string propertySearch);
        /// <summary>
        /// Lấy theo id
        /// </summary>
        /// <returns>1 đối tượng</returns>
        /// CreatedBy: LVDat (26/5/2021)
        ActionServiceResult GetEntityById(Guid entityId);
        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">đối tượng thêm mới</param>
        /// <returns>Số dòng ảnh hưởng</returns>
        ///  CreatedBy: LVDat (26/5/2021)
        ActionServiceResult AddEntity(TEntity entity);
        /// <summary>
        /// Sửa thông tin đối tượng
        /// </summary>
        /// <param name="entity">Thông tin mới</param>
        /// <returns>Số dòng ảnh hưởng</returns>
        /// CreatedBy: LVDat (26/5/2021)
        ActionServiceResult UpdateEntity(TEntity entity);
        /// <summary>
        /// Xoá theo id
        /// </summary>
        /// <param name="entityId">Id cần xoá</param>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        /// CreatedBy: LVDat (26/5/2021)
        ActionServiceResult DeleteEntity(Guid entityId);
        /// <summary>
        /// Phân trang danh sách entity
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        ActionServiceResult PagingEntity(string entityInfo);

        /// <summary>
        /// Xoá danh sách theo id
        /// </summary>
        /// <param name="guids">đânh sách id</param>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        ActionServiceResult DeeteMultiple(Guid[] guids);
    }
}
