using Eskitech.Entities.Categories;
using Eskitech.Infrastructure.DbContexts;
using Eskitech.Infrastructure.Seeding;
using Microsoft.Extensions.Logging;

namespace Eskitech.Domain.Categories
{
    public class CategoryDataContributor(EskitechDbContext dbContext, ILogger<CategoryDataContributor> logger)
        : DataSeedContributor<EskitechDbContext>(dbContext, logger)
    {
        protected override int SeedData()
        {
            if (DbContext.Categories.Any()) return 0;

            DbContext.Categories.Add(new Category { Name = "Löparskor", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Yoga & hemmaträning", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Bollsport", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Cyckling", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Herrkläder", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Damkläder", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Simning", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Träningsutrustning", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Fitness Tracker", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Kampsport", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Sportkläder för barn", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Outdoor & Äventyr", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Gymnastik & Dans", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Sportväskor & Ryggsäckar", CreatedAt = DateTime.UtcNow });

            return DbContext.SaveChanges();
        }
    }
}