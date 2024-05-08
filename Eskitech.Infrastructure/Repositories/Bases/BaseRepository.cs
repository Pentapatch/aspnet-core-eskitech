using Eskitech.Entities.Bases;
using Microsoft.EntityFrameworkCore;

namespace Eskitech.Infrastructure.Repositories
{
    public abstract class BaseRepository<TDbContext, TEntity>(TDbContext dbContext)
        : IBaseRepository<TEntity> where TDbContext : DbContext where TEntity : Entity
    {
        protected TDbContext DbContext { get; } = dbContext;

        public virtual IEnumerable<TEntity> GetAll() =>
            DbContext.Set<TEntity>()
                .ToList();

        public virtual IEnumerable<TEntity> GetAllPaginated(int page, int pageSize) =>
            DbContext.Set<TEntity>()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

        public virtual int GetTotalCount() =>
            DbContext.Set<TEntity>().Count();

        public virtual TEntity? GetById(int id) =>
            DbContext.Set<TEntity>()
                .FirstOrDefault(p => p.Id == id);

        public virtual void Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            DbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Update(entity);
            DbContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            DbContext.SaveChanges();
        }
    }
}