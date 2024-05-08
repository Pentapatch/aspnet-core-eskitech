using Eskitech.Domain.Bases;
using Microsoft.EntityFrameworkCore;

namespace Eskitech.Data.Base
{
    public abstract class AuditedBaseRepository<TDbContext, TEntity>(TDbContext dbContext)
        : IBaseRepository<TEntity> where TDbContext : DbContext where TEntity : AuditedEntity
    {
        protected TDbContext DbContext { get; } = dbContext;

        public virtual IEnumerable<TEntity> GetAll() => 
            DbContext.Set<TEntity>()
                .Where(e => !e.IsDeleted)
                .ToList();

        public virtual TEntity? GetById(int id) => 
            DbContext.Set<TEntity>()
                .Where(e => !e.IsDeleted)
                .FirstOrDefault(p => p.Id == id);

        public virtual void Add(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;

            DbContext.Set<TEntity>().Add(entity);
            DbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;

            DbContext.Set<TEntity>().Update(entity);
            DbContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            entity.DeletedAt = DateTime.Now;
            entity.IsDeleted = true;

            DbContext.Set<TEntity>().Update(entity);
            DbContext.SaveChanges();
        }

        public virtual void Restore(TEntity entity)
        {
            entity.DeletedAt = null;
            entity.IsDeleted = false;

            DbContext.Set<TEntity>().Update(entity);
            DbContext.SaveChanges();
        }
    }
}