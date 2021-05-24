using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        IBaseRepository<TEntity> _baseRepository;
        #region Constructor
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion
        public ActionServiceResult AddEntity(TEntity entity)
        {
            try
            {
                return new ActionServiceResult()
                {
                    Message = "Thêm thành công",
                    Success = true,
                    MISAcode = Enumeration.MISAcode.Success,
                    data = _baseRepository.AddEntity(entity)
                };
            }
            catch (Exception e)
            {
                return new ActionServiceResult()
                {
                    Message = "Thêm không thành công",
                    Success = false,
                    MISAcode = Enumeration.MISAcode.Exception,
                    data = 0
                };
            }

        }

        public ActionServiceResult DeleteEntity(Guid entityId)
        {
            return new ActionServiceResult()
            {
                Message = "Xoá thành công",
                Success = true,
                MISAcode = Enumeration.MISAcode.Success,
                data = _baseRepository.DeleteEntity(entityId)
            };
        }

        public ActionServiceResult GetEntities()
        {
            return new ActionServiceResult()
            {
                Message = "Thành công",
                Success = true,
                MISAcode = Enumeration.MISAcode.Success,
                data = _baseRepository.GetEntities()
            };
        }

        public ActionServiceResult GetEntityById(Guid entityId)
        {
            var entity = _baseRepository.DeleteEntity(entityId);
            if (entity != null)
            {
                return new ActionServiceResult()
                {
                    Message = "Thành công",
                    Success = true,
                    MISAcode = Enumeration.MISAcode.Success,
                    data = entity
                };
            }
            else
            {
                return new ActionServiceResult()
                {
                    Message = "Không tìm thấy",
                    Success = true,
                    MISAcode = Enumeration.MISAcode.Howllow,
                    data = null
                };
            }
        }

        public ActionServiceResult UpdateEntity(TEntity entity)
        {
                return new ActionServiceResult()
                {
                    Success = true,
                    Message = "Thành công",
                    MISAcode = Enumeration.MISAcode.Success,
                    data = _baseRepository.UpdateEntity(entity)
                };
           
        }
    }
}
