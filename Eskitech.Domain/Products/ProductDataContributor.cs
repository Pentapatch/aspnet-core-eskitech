using Eskitech.Entities.Products;
using Eskitech.Infrastructure.DbContexts;
using Eskitech.Infrastructure.Seeding;
using Microsoft.Extensions.Logging;

namespace Eskitech.Domain.Products
{
    public class ProductDataContributor(EskitechDbContext dbContext, ILogger<ProductDataContributor> logger)
        : DataSeedContributor<EskitechDbContext>(dbContext, logger)
    {
        protected override int SeedData()
        {
            if (DbContext.Products.Any()) return 0;

            DbContext.Products.Add(new Product
            {
                Name = "Nike Air Zoom Pegasus 38",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Högpresterande löparskor med responsiv dämpning och ventilerande material för ökad komfort under långa löprundor.",
                Price = 1200m,
                StockQuantity = 80,
                Brand = "Nike",
                CategoryId = 1,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Liforme Yoga Mat",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Premium yogamatta tillverkad av miljövänligt material med optimalt grepp och stöd för yogautövare på alla nivåer.",
                Price = 900m,
                StockQuantity = 60,
                Brand = "Liforme",
                CategoryId = 2,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Adidas Finale 21 Competition",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Officiell matchboll för UEFA Champions League med högkvalitativt yttre skikt för precision och kontroll.",
                Price = 400m,
                StockQuantity = 105,
                Brand = "Adidas",
                CategoryId = 3,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "POC Ventral Air Spin",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Aerodynamisk cykelhjälm med avancerat ventilationssystem och SPIN-teknologi för maximal säkerhet och komfort.",
                Price = 1500m,
                StockQuantity = 39,
                Brand = "POC",
                CategoryId = 4,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Nike Mercurial Superfly 8 Elite FG",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Fotbollsskor designade för snabbhet och bollkontroll, med en anatomisk passform och innovativa material för ökad prestanda på planen.",
                Price = 1800m,
                StockQuantity = 55,
                Brand = "Nike",
                CategoryId = 3,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Gaiam Essentials Yoga Block",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Yoga-block tillverkat av lättviktig skum för ökad stabilitet och stöd under yogapositioner och stretchövningar.",
                Price = 150m,
                StockQuantity = 75,
                Brand = "Gaiam",
                CategoryId = 2,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "PEARL iZUMi Men's Select Gloves",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Cykelhandskar med gel-vaddering och andningsbar mesh för ökad komfort och grepp under cykelturer.",
                Price = 250m,
                StockQuantity = 45,
                Brand = "PEARL iZUMi",
                CategoryId = 4,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Under Armour Men's Tech 2.0 Short Sleeve T-Shirt",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Funktionell herrtröja tillverkad av snabbtorkande material för optimal komfort under träning och vardagsaktiviteter.",
                Price = 300m,
                StockQuantity = 65,
                Brand = "Under Armour",
                CategoryId = 5,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Nike Women's Tempo Running Shorts",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Damshorts med Dri-FIT-teknologi för fuktavledning och inbyggda tights för ökad täckning och support under löpning och träning.",
                Price = 250m,
                StockQuantity = 80,
                Brand = "Nike",
                CategoryId = 6,
                CreatedAt = DateTime.UtcNow
            });

            return DbContext.SaveChanges();
        }
    }
}