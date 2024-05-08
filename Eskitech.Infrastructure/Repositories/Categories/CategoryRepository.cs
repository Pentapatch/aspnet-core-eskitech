using Eskitech.Entities.Categories;
using Eskitech.Infrastructure.DbContexts;

namespace Eskitech.Infrastructure.Repositories
{
    public sealed class CategoryRepository(EskitechDbContext dbContext)
        : AuditedBaseRepository<EskitechDbContext, Category>(dbContext)
    {

    }
}