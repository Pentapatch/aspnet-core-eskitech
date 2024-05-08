using Eskitech.Data.Base;
using Eskitech.Domain.Products;
using Eskitech.Infrastructure.DbContexts;

namespace Eskitech.Data.Products
{
    public sealed class ProductRepository(EskitechDbContext dbContext) 
        : AuditedBaseRepository<EskitechDbContext, Product>(dbContext)
    {

    }
}
