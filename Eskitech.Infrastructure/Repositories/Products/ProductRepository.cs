using Eskitech.Entities.Products;
using Eskitech.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Eskitech.Infrastructure.Repositories
{
    public sealed class ProductRepository(EskitechDbContext dbContext)
        : AuditedBaseRepository<EskitechDbContext, Product>(dbContext)
    {
        public override Product? GetById(int id) =>
            DbContext.Set<Product>()
                .Include(p => p.Category)
                .Where(e => !e.IsDeleted)
                .FirstOrDefault(p => p.Id == id);

        public override IEnumerable<Product> GetAll() =>
            DbContext.Set<Product>()
                .Include(p => p.Category)
                .Where(e => !e.IsDeleted)
                .ToList();
    }
}
