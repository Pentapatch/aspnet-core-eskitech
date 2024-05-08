using Eskitech.Entities.Categories;
using Eskitech.Infrastructure.DbContexts;

namespace Eskitech.Infrastructure.Seeding
{
    public class CategoryDataContributor(EskitechDbContext dbContext)
        : DataSeedContributor<EskitechDbContext>(dbContext)
    {
        public override void SeedData()
        {
            if (DbContext.Categories.Any()) return;

            DbContext.Categories.Add(new Category { Name = "Category 1", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Category 2", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Category 3", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Category 4", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Category 5", CreatedAt = DateTime.UtcNow });

            DbContext.SaveChanges();
        }
    }
}