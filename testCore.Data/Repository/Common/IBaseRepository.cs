using Arch.EntityFrameworkCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace testCore.Data
{//to impimant forced features
    public interface IBaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IBaseEntity
    {
        void SetAuditableInfo(TEntity entity);
    }
}
