using Eskitech.Entities.Products;
using Eskitech.Infrastructure.DbContexts;

namespace Eskitech.Infrastructure.Repositories
{
    public sealed class ProductRepository(EskitechDbContext dbContext)
        : AuditedBaseRepository<EskitechDbContext, Product>(dbContext)
    {

    }
}
