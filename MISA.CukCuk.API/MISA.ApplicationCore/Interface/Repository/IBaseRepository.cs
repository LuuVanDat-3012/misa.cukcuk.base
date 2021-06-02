using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns>danh sách đối tượng</returns>
        /// CreatedBy: LVDat (20/5/2021)
        List<TEntity> GetEntities();
        /// <summary>
        /// Lấy đối tượng theo ID
        /// </summary>
        /// <returns>1 đối tượng</returns>
        /// CreatedBy: LVDat (20/5/2021)
        TEntity GetEntityById(Guid entityId);
        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <returns>Số dòng ảnh hưởng</returns>
        /// CreatedBy: LVDat (20/5/2021)
        int AddEntity(TEntity entity);
        /// <summary>
        /// Sửa thông tin đối tượng
        /// </summary>
        /// <returns>Số dòng ảnh hưởng</returns>
        /// CreatedBy: LVDat (20/5/2021)
        int UpdateEntity(TEntity entity);
        /// <summary>
        /// Xoá đối tượng
        /// </summary>
        /// <returns>Số dòng ảnh hưởng</returns>
        /// CreatedBy: LVDat (20/5/2021)
        int DeleteEntity(Guid TEntityId);
        TEntity GetEntityByProperty(string propertyName, object propertyValue);
    }
}
