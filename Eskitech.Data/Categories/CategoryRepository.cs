using Eskitech.Data.Base;
using Eskitech.Domain.Categories;
using Eskitech.Infrastructure.DbContexts;

namespace Eskitech.Data.Categories
{
    public sealed class CategoryRepository(EskitechDbContext dbContext)
        : AuditedBaseRepository<EskitechDbContext, Category>(dbContext)
    {

    }
}