using Eskitech.Entities.Products;
using Eskitech.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eskitech.Infrastructure.Repositories
{
    public sealed class ProductRepository(EskitechDbContext dbContext, ILogger<AuditedBaseRepository<EskitechDbContext, Product>> logger)
        : AuditedBaseRepository<EskitechDbContext, Product>(dbContext, logger)
    {
        public override Product? GetById(int id) =>
            DbContext.Set<Product>()
                .Include(p => p.Category)
                .Where(p => !p.IsDeleted)
                .FirstOrDefault(p => p.Id == id);

        public override IEnumerable<Product> GetAll() =>
            DbContext.Set<Product>()
                .Include(p => p.Category)
                .Where(p => !p.IsDeleted)
                .ToList();

        public override IEnumerable<Product> GetAllPaginated(int page, int pageSize) =>
            DbContext.Set<Product>()
                .Include(p => p.Category)
                .Where(p => !p.IsDeleted)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
    }
}
