using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace testCore.Data
{
    public abstract class BaseRepository<TEntity, TDbContext> : Repository<TEntity>, IBaseRepository<TEntity>
         where TEntity : class, IBaseEntity
         where TDbContext : DbContext
    {
        protected BaseRepository(TDbContext dbContext) : base(dbContext)
        {
        }
        public void SetAuditableInfo(TEntity entity)
        {
            if (entity is IBaseEntity<int> auditable_Entity)
            {
                if(auditable_Entity.Id == 0)
                {
                    auditable_Entity.Created_On = DateTime.Now;
                    _dbContext.Entry(auditable_Entity).Property(p => p.LastUpdatedDate).IsModified = false;
                }
                else
                {
                    auditable_Entity.LastUpdatedDate = DateTime.Now;
                    _dbContext.Entry(auditable_Entity).Property(p => p.Created_On).IsModified = false;
                }
            }
                }
    }
}
