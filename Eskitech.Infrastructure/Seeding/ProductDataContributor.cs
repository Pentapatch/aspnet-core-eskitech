using Eskitech.Domain.Products;
using Eskitech.Infrastructure.DbContexts;

namespace Eskitech.Infrastructure.Seeding
{
    public class ProductDataContributor(EskitechDbContext dbContext)
        : DataSeedContributor<EskitechDbContext>(dbContext)
    {
        public override void SeedData()
        {
            if (DbContext.Products.Any()) return;

            DbContext.Products.Add(new Product
            {
                Name = "Product 1",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Description for Product 1",
                Price = 100m,
                StockQuantity = 100,
                Brand = "Brand 1",
                CategoryId = 1
            });

            DbContext.Products.Add(new Product
            {
                Name = "Product 2",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Description for Product 2",
                Price = 200m,
                StockQuantity = 50,
                Brand = "Brand 1",
                CategoryId = 2
            });

            DbContext.SaveChanges();
        }
    }
}