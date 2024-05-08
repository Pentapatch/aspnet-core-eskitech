using Eskitech.Entities.Categories;
using Eskitech.Infrastructure.DbContexts;
using Microsoft.Extensions.Logging;

namespace Eskitech.Infrastructure.Repositories
{
    public sealed class CategoryRepository(EskitechDbContext dbContext, ILogger<AuditedBaseRepository<EskitechDbContext, Category>> logger)
        : AuditedBaseRepository<EskitechDbContext, Category>(dbContext, logger)
    {

    }
}