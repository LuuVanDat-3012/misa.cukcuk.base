using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    public interface IBaseRepository<TEntity>
    {
        List<TEntity> GetEntities();
        TEntity GetEntityById(Guid entityId);
        int AddEntity(TEntity entity);
        int UpdateEntity(TEntity entity);
        int DeleteEntity(Guid TEntityId);
    }
}
