using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy danh sách đối tượng
        /// </summary>
        /// <returns>1 danh sách đối tượng</returns>
        /// CreatedBy: LVDat (26/5/2021)
        ActionServiceResult GetEntities();
        /// <summary>
        /// Lấy theo id
        /// </summary>
        /// <param name="entityId">id cần tìm</param>
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
    }
}
