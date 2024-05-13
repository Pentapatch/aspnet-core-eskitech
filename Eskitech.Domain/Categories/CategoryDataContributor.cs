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

            DbContext.Categories.Add(new Category { Name = "Hjämar", CreatedAt = DateTime.UtcNow });              // 1
            DbContext.Categories.Add(new Category { Name = "Goggles", CreatedAt = DateTime.UtcNow }); // 2
            DbContext.Categories.Add(new Category { Name = "Ryggskydd", CreatedAt = DateTime.UtcNow });           // 3
            DbContext.Categories.Add(new Category { Name = "Lavinutrustning", CreatedAt = DateTime.UtcNow });            // 4
            DbContext.Categories.Add(new Category { Name = "Skidväskor", CreatedAt = DateTime.UtcNow });          
            DbContext.Categories.Add(new Category { Name = "Böcker", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Offpistskidor", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Mountainskidor", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Topptursskidor", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Twintipskidor", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Pistskidor", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Alpinpjäxor", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Toppturpjäxor", CreatedAt = DateTime.UtcNow });
            DbContext.Categories.Add(new Category { Name = "Telemarkspjäxor", CreatedAt = DateTime.UtcNow });

            return DbContext.SaveChanges();
        }
    }
}