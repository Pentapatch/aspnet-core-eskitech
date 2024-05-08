using Eskitech.Entities.Categories;
using Eskitech.Infrastructure.DbContexts;
using Eskitech.Infrastructure.Seeding;

namespace Eskitech.Domain.Categories
{
    public class CategoryDataContributor(EskitechDbContext dbContext)
        : DataSeedContributor<EskitechDbContext>(dbContext)
    {
        public override void SeedData()
        {
            if (DbContext.Categories.Any()) return;

            DbContext.Categories.Add(new Category { Name = "Löparskor", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Yoga & hemmaträning", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Bollsport", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Cyckling", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Herrkläder", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Damkläder", CreatedAt = DateTime.UtcNow });

            DbContext.SaveChanges();
        }
    }
}