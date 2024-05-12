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
                Price = 1199m,
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
                Price = 429m,
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
                Price = 399m,
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
                Price = 1799m,
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
                Price = 149m,
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
                Price = 269m,
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
                Price = 299m,
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
                Price = 249m,
                StockQuantity = 80,
                Brand = "Nike",
                CategoryId = 6,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Speedo Swim Goggles",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Simglasögon utformade för optimal passform och synlighet i vattnet, med imskyddsbeläggning och UV-skydd för förbättrad prestanda.",
                Price = 299m,
                StockQuantity = 50,
                Brand = "Speedo",
                CategoryId = 7,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Bowflex Justerbara Vikter",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Justerbara hantlar med ett unikt vridsystem för snabb viktförändring, vilket ger en mångsidig och platsbesparande lösning för styrketräning hemma.",
                Price = 699m,
                StockQuantity = 25,
                Brand = "Bowflex",
                CategoryId = 8,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Fitbit Charge 4 Fitness- och Aktivitetsspårare",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Avancerad aktivitetsspårare med inbyggd GPS, pulsmätning och sömnspårningsfunktioner, vilket ger insikter om daglig aktivitet och hälsometriker.",
                Price = 1699m,
                StockQuantity = 40,
                Brand = "Fitbit",
                CategoryId = 9,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Everlast Powercore Fristående Säck",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Fristående träningsväska designad för intensiva boxnings- och kampsportsträningar, med hållbar konstruktion och stötdämpande stoppning för optimal prestanda.",
                Price = 250m,
                StockQuantity = 20,
                Brand = "Everlast",
                CategoryId = 10,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Nike Kids' Revolution 5 Förskole Skor",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Förskole skor med lättviktsdämpning och ventilerande material för komfort och stöd under aktivt lek.",
                Price = 499m,
                StockQuantity = 60,
                Brand = "Nike",
                CategoryId = 11,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Garmin Forerunner 245 GPS Löparklocka",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Avancerad GPS löparklocka med prestandamätning, inklusive VO2 max och träningsstatusbedömningar, för att hjälpa till att förbättra löpeffektiviteten.",
                Price = 2999m,
                StockQuantity = 34,
                Brand = "Garmin",
                CategoryId = 12,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "TheraBand Motståndsband Set",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Set med motståndsband med olika nivåer av motstånd för styrketräning, rehabilitering och fysioterapiövningar, lämpliga för alla träningsnivåer.",
                Price = 299m,
                StockQuantity = 77,
                Brand = "TheraBand",
                CategoryId = 13,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Casio G-Shock Herrklocka",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Tålig och stötsäker herrklocka med flera funktioner, inklusive stoppur, nedräkningsklocka och vattentäthet upp till 200 meter, lämplig för utomhusaktiviteter.",
                Price = 999m,
                StockQuantity = 50,
                Brand = "Casio",
                CategoryId = 8,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Spalding NBA Street Basketboll",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Utomhusbasketboll med slitstarkt gummiöverdrag och djupa kanaler för förbättrat grepp och kontroll, designad för gatubasket och utomhuslek.",
                Price = 229m,
                StockQuantity = 42,
                Brand = "Spalding",
                CategoryId = 3,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Nike Fundamental Speed Rep",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Speed rep designad för höghastighetshoppande träningar, med lättviktiga handtag och justerbar längd för anpassningsbara träningspass.",
                Price = 179m,
                StockQuantity = 61,
                Brand = "Nike",
                CategoryId = 2,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Osprey Farpoint 40 Reseväska",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Reseväska med ergonomisk design och mångsidiga funktioner, inklusive en avtagbar dagsryggsäck och vadderat laptopfack, lämplig för korta resor och vardagsbruk.",
                Price = 1400m,
                StockQuantity = 35,
                Brand = "Osprey",
                CategoryId = 14,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Fitbit Charge 4 Fitness- och aktivitetsspårare",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Avancerad aktivitetsspårare med inbyggd GPS, pulsmätning och funktioner för aktivitetsspårning, utformad för att hjälpa dig uppnå dina träningsmål och hålla dig uppkopplad när du är på språng.",
                Price = 1599m,
                StockQuantity = 25,
                Brand = "Fitbit",
                CategoryId = 11,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Adidas Copa Mundial Fotbollsskor",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Klassiska fotbollsskor med slitstark ovandel av känguruläder och fast mark-sula för optimalt grepp och bollkontroll, betrodda av professionella spelare över hela världen.",
                Price = 2229m,
                StockQuantity = 26,
                Brand = "Adidas",
                CategoryId = 10,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Under Armour Hustle 5.0 Ryggsäck",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Mångsidig ryggsäck med vattenavvisande yta och vadderat fack för bärbar dator, lämplig för dagliga pendlingar, gymsessioner och resor, vilket ger hållbarhet och organisation.",
                Price = 1299m,
                StockQuantity = 38,
                Brand = "Under Armour",
                CategoryId = 13,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Speedo Vanquisher 2.0 Simglasögon",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Simglasögon med panoramiska linser och imskyddsbeläggning, vilket ger förbättrad synlighet och komfort under simsessioner, lämpliga för både fritids- och tävlingssimmare.",
                Price = 199m,
                StockQuantity = 35,
                Brand = "Speedo",
                CategoryId = 7,
                CreatedAt = DateTime.UtcNow
            });

            return DbContext.SaveChanges();
        }
    }
}