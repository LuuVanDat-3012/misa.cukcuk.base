using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    public interface IBaseService<TEntity>
    {
        ActionServiceResult GetEntities();
        ActionServiceResult GetEntityById(Guid entityId);
        ActionServiceResult AddEntity(TEntity entity);
        ActionServiceResult UpdateEntity(TEntity entity);
        ActionServiceResult DeleteEntity(Guid entityId);
    }
}
