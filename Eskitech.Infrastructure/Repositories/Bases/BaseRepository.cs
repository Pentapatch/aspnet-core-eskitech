using Eskitech.Entities.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eskitech.Infrastructure.Repositories
{
    public abstract class BaseRepository<TDbContext, TEntity>(TDbContext dbContext, ILogger<BaseRepository<TDbContext, TEntity>> logger)
        : IBaseRepository<TEntity> where TDbContext : DbContext where TEntity : Entity
    {
        private readonly ILogger<BaseRepository<TDbContext, TEntity>> _logger = logger;

        protected TDbContext DbContext { get; } = dbContext;

        public virtual IEnumerable<TEntity> GetAll() =>
            DbContext.Set<TEntity>()
                .ToList();

        public virtual IEnumerable<TEntity> GetAllPaginated(int page, int pageSize) =>
            DbContext.Set<TEntity>()
                .OrderBy(e => e.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

        public virtual int GetTotalCount() =>
            DbContext.Set<TEntity>().Count();

        public virtual TEntity? GetById(int id) =>
            DbContext.Set<TEntity>()
                .FirstOrDefault(e => e.Id == id);

        public virtual void Add(TEntity entity)
        {
            try
            {
                DbContext.Set<TEntity>().Add(entity);
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new entity of type {EntityType}", typeof(TEntity).Name);
                throw;
            }
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                DbContext.Set<TEntity>().Update(entity);
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating an entity of type {EntityType}", typeof(TEntity).Name);
                throw;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            try
            {
                DbContext.Set<TEntity>().Remove(entity);
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting an entity of type {EntityType}", typeof(TEntity).Name);
                throw;
            }
        }
    }
}