using Eskitech.Infrastructure.DbContexts;
using Eskitech.Infrastructure.Seeding;

namespace Eskitech.Domain.Products
{
    public class ProductDataContributor(EskitechDbContext dbContext)
        : DataSeedContributor<EskitechDbContext>(dbContext)
    {
        public override void SeedData()
        {
            // TODO: Seed products, i.e.:
            //DbContext.Products.Add(new Product
            //{
            //    Name = "Product 1",
            //    Description = "Description for Product 1",
            //    Price = 100
            //});

            //DbContext.SaveChanges();
        }
    }
}