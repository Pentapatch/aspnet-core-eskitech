using Eskitech.Entities.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eskitech.Infrastructure.Repositories
{
    public abstract class AuditedBaseRepository<TDbContext, TEntity>(TDbContext dbContext, ILogger<AuditedBaseRepository<TDbContext, TEntity>> logger)
        : IBaseRepository<TEntity> where TDbContext : DbContext where TEntity : AuditedEntity
    {
        private readonly ILogger<AuditedBaseRepository<TDbContext, TEntity>> _logger = logger;

        protected TDbContext DbContext { get; } = dbContext;

        public virtual IEnumerable<TEntity> GetAll() =>
            DbContext.Set<TEntity>()
                .Where(e => !e.IsDeleted)
                .ToList();

        public virtual IEnumerable<TEntity> GetAllPaginated(int page, int pageSize) =>
            DbContext.Set<TEntity>()
                .Where(e => !e.IsDeleted)
                .OrderBy(e => e.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

        public virtual int GetTotalCount() =>
            DbContext.Set<TEntity>().Count(e => !e.IsDeleted);

        public virtual TEntity? GetById(int id) =>
            DbContext.Set<TEntity>()
                .Where(e => !e.IsDeleted)
                .FirstOrDefault(e => e.Id == id);

        public virtual void Add(TEntity entity)
        {
            try
            {
                entity.CreatedAt = DateTime.UtcNow;

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
                entity.UpdatedAt = DateTime.UtcNow;

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
                entity.DeletedAt = DateTime.UtcNow;
                entity.IsDeleted = true;

                DbContext.Set<TEntity>().Update(entity);
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting an entity of type {EntityType}", typeof(TEntity).Name);
                throw;
            }
        }

        public virtual void Restore(TEntity entity)
        {
            try
            {
                entity.DeletedAt = null;
                entity.IsDeleted = false;

                DbContext.Set<TEntity>().Update(entity);
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while restoring an entity of type {EntityType}", typeof(TEntity).Name);
                throw;
            }
        }
    }
}