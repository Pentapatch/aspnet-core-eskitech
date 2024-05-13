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
                Name = "Obex MIPS Uranium Black Matt",
                ProductId = Guid.NewGuid().ToString(),
                Description = "POC Obex MIPS använder sig av ett delat skal för att sprida ut energin från en smäll så effektivt som möjligt.",
                LongDescription = "POC Obex MIPS använder sig av ett delat skal för att sprida ut energin från en smäll så effektivt som möjligt. Hjälmen är lätt och luftig med justerbar ventilation så att du kan stänga till på vintern kallaste dagar när du vill behålla så mycket värme som möjligt.",
                Price = 1995m,
                StockQuantity = 80,
                Brand = "POC",
                CategoryId = 1,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Trooper 2Vi MIPS Helmet Dirt Black",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Sweet Protection har gjort en rejäl uppdatering på sin klassiska hjälm Trooper.",
                LongDescription = "Sweet Protection har gjort en rejäl uppdatering på sin klassiska hjälm Trooper. Senaste modellen, Trooper 2Vi, är både lättare och ger ett bättre skydd än föregående modell. I hjärtat av den nya konstruktionen ligger ett tvålagers rotationsskydd som med hjälp av MIPS minskar risken för hjärnskakningar.",
                Price = 3195m,
                StockQuantity = 60,
                Brand = "Sweet Protection",
                CategoryId = 1,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "M5 Smoke/PRCV Sun Onyx",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Anon M5 Perceive är en unisex design som passar medelstora och stora ansikten och kommer med en bonuslins.",
                LongDescription = "Anon M5 Perceive är en unisex design som passar medelstora och stora ansikten och kommer med en bonuslins. Perceive-linsen ger hög kontrast och klarhet i nästan alla ljusförhållanden; En hydrofob och oleofob beläggning ger oöverträffad smuts-, repnings- och fuktbeständighet på den yttre linsens yta för bra optik och enkel rengöring.",
                Price = 3495m,
                StockQuantity = 105,
                Brand = "Anon",
                CategoryId = 2,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Opsin Selentine White/Partly Sunny Ivory",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Opsin har en tidlös och klassisk design som passar de flesta ansikten och hjälmar.",
                LongDescription = "Opsin har en tidlös och klassisk design som passar de flesta ansikten och hjälmar. Sfäriska Clarity Comp linser från Carl Zeiss med deras bästa kontrasthöjande effekter för absolut syn, oavsett väderförhållande.",
                Price = 1395m,
                StockQuantity = 39,
                Brand = "POC",
                CategoryId = 2,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Live Shield Vest AMID M Black",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Atomic Live Shield Vest AMID har blivit lite av en personalfavorit här på Skistore.",
                LongDescription = "Atomic Live Shield Vest AMID har blivit lite av en personalfavorit här på Skistore. Vi har nog aldrig testat ett ryggskydd som är så här mjukt och följsamt, man har glömt av att man har det på sig ungefär samtidigt som jackan åker på.",
                Price = 2395m,
                StockQuantity = 55,
                Brand = "Atomic",
                CategoryId = 3,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Live Shield Vest AMID M Red",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Atomic Live Shield Vest AMID har blivit lite av en personalfavorit här på Skistore.",
                LongDescription = "Atomic Live Shield Vest AMID har blivit lite av en personalfavorit här på Skistore. Vi har nog aldrig testat ett ryggskydd som är så här mjukt och följsamt, man har glömt av att man har det på sig ungefär samtidigt som jackan åker på. Och tänk då på att det här är ett level 2 klassat ryggskydd, dvs. godkänt för MC!",
                Price = 2395m,
                StockQuantity = 75,
                Brand = "Atomic",
                CategoryId = 3,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Recon LT",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Black Diamond Recon LT är den lättaste lavinsändaren på marknaden och riktar sig till den viktmedvetna topptursåkaren.",
                LongDescription = "Black Diamond Recon LT är den lättaste lavinsändaren på marknaden och riktar sig till den viktmedvetna topptursåkaren. Här får du alla features som man vill ha i en lavinsändare till minimal vikt. De tre antennerna med ett cirkulärt sökområde på 50m ger en snabb och träffsäker sökning av ett lavinområde.",
                Price = 3895m,
                StockQuantity = 45,
                Brand = "Black Diamond",
                CategoryId = 4,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Avi Shovel",
                ProductId = Guid.NewGuid().ToString(),
                Description = "G3 Avi är en pålitlig lavinspade för dig som vill ha det mest effektiva verktyget om olyckan skulle vara framme.",
                LongDescription = "G3 Avi är en pålitlig lavinspade för dig som vill ha det mest effektiva verktyget om olyckan skulle vara framme. Det stora bladet gör att du skyfflar bort stora mängder snö åt gången och tillsammans med de utskurna hålen funkar den även utmärkt som släde i en nödsituation.",
                Price = 895m,
                StockQuantity = 65,
                Brand = "G3",
                CategoryId = 4,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Patrol E2 30",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Scott Patrol E2 30 Kit är en väldigt populär friåknings lavinryggsäck som är klockren för liftburen åkning och dagsturer.",
                LongDescription = "Scott Patrol E2 30 Kit är en väldigt populär friåknings lavinryggsäck som är klockren för liftburen åkning och dagsturer. Systemet är eldrivet med hjälp av en superkapacitator som blåser upp ballongen snabbt.",
                Price = 14995m,
                StockQuantity = 8,
                Brand = "Scott",
                CategoryId = 5,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Jetforce UL Pack 26L",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Jetforce UL (Ultra Light) är en av de lättaste lavinryggsäckarna 20/21.",
                LongDescription = "Jetforce UL (Ultra Light) är en av de lättaste lavinryggsäckarna 20/21. Lavinsystemet bygger på Alpride 2.0 som är superlätt och väldigt smidigt att använda. Luftpatronerna kombinerar argongas och CO2 som ger en kraftfull effekt och blåser upp den 150L stora ballongen på mindre än 5 sekunder.",
                Price = 9495m,
                StockQuantity = 29,
                Brand = "Speedo",
                CategoryId = 5,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Lavinboken",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Lavinboken är skriven för dig som älskar att åka offpist och gå på toppturer.",
                LongDescription = "Lavinboken är skriven för dig som älskar att åka offpist och gå på toppturer. Med andra ord - för dig som på egen hand måste kunna avgöra om det är säkert att åka på sluttningen du har framför dig. Steg för steg får du lära dig lavinriskbedömning, kamraträddning och hur du minskar riskerna uppför och utför.",
                Price = 269m,
                StockQuantity = 25,
                Brand = "",
                CategoryId = 6,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Skidhistorier - Om världens bästa offpiståkning, toppturer och skidäventyr",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Avancerad aktivitetsspårare med inbyggd GPS, pulsmätning och sömnspårningsfunktioner, vilket ger insikter om daglig aktivitet och hälsometriker.",
                LongDescription = "Avancerad aktivitetsspårare med inbyggd GPS, pulsmätning och sömnspårningsfunktioner, vilket ger insikter om daglig aktivitet och hälsometriker.",
                Price = 395m,
                StockQuantity = 40,
                Brand = "",
                CategoryId = 6,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Bent 110 23/24",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Atomic BENT 110 är designad av Chris Benchetler och Atomic Freeski team och är verkligen en skida för hela berget.",
                LongDescription = "Atomic BENT 110 är designad av Chris Benchetler och Atomic Freeski team och är verkligen en skida för hela berget. Lekfull, kvick men likväl kraftfull så klarar BENT 110 både puder, skogsåkning och samtidigt ha maximalt roligt i pisten.",
                Price = 6795m,
                StockQuantity = 20,
                Brand = "Atomic",
                CategoryId = 7,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Atris Birdie 23/24",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Black Crows Atris Birdie har länge varit en stor favorit och en av våra absolut mest sålda skidor de senaste åren.",
                LongDescription = "Black Crows Atris Birdie har länge varit en stor favorit och en av våra absolut mest sålda skidor de senaste åren. Till säsongen 22/23 fick den en uppdatering inte bara i grafik utan även i shape för at bli ännu lite mer följsam och surfig.",
                Price = 7995m,
                StockQuantity = 16,
                Brand = "Black Crows",
                CategoryId = 7,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "ARV 94 23/24",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Armada ARV 94 är en helt ny skida för säsongen 23/24 och det är nog många som längtat efter en sån här skida från Armada.",
                LongDescription = "Armada ARV 94 är en helt ny skida för säsongen 23/24 och det är nog många som längtat efter en sån här skida från Armada. Med ett mjukare flex än sin föregångare så är den nu mer lekfull och balanserad.",
                Price = 5995m,
                StockQuantity = 14,
                Brand = "Armada",
                CategoryId = 8,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Enduro 100",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Norse The Enduro är en all mountainskida för dig som vill ha något för alla tillfällen.",
                LongDescription = "Norse The Enduro är en all mountainskida för dig som vill ha något för alla tillfällen. Uppdaterad till iår både i konstruktion och design. Skidan har blivit lite mjukare i nosen för att snabbare komma in i sväng och bli lite mer följsam över uppåkt och stökig snö.",
                Price = 7895m,
                StockQuantity = 7,
                Brand = "Norse Skis",
                CategoryId = 8,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Hustle 11 23/24",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Blizzard Hustle 11 är grym friåkningsskida för dig som gillar dämpade och stabila skidor.",
                LongDescription = "Blizzard Hustle 11 är grym friåkningsskida för dig som gillar dämpade och stabila skidor. Samma shape som den omåttligt populära Rustler 11 men utan titanalförstärkningen vilket gör skidan lättare och mer följsam.",
                Price = 7495m,
                StockQuantity = 5,
                Brand = "Blizzard",
                CategoryId = 9,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Fusion 95 Carbon 23/24",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Extrem Fusion 95 Carbon är en skida som sticker ut lite från mängden.",
                LongDescription = "Extrem Fusion 95 Carbon är en skida som sticker ut lite från mängden. Vanligtvis ser vi att skidtillverkare använder kolfiber för att göra så lätta skidor som möjligt. Och medan det absolut är en positiv bieffekt även här så är huvudsyftet faktiskt att öka skidornas prestanda i form av vridstyvhet och dämpning.",
                Price = 8495m,
                StockQuantity = 12,
                Brand = "Extrem",
                CategoryId = 9,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Reckoner 92 23/24",
                ProductId = Guid.NewGuid().ToString(),
                Description = "K2 Reckoner 92 är en utmärkt skida för dig som är sugen på att skaffa dina första twin-tip skidor.",
                LongDescription = "K2 Reckoner 92 är en utmärkt skida för dig som är sugen på att skaffa dina första twin-tip skidor. Mera inriktad för resortåkning är Reckoner 92 en super härlig skida att hänga med i parken och även cruisa ner i pisten, slashandes och sladdades runt.",
                Price = 3995m,
                StockQuantity = 6,
                Brand = "K2",
                CategoryId = 10,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Honey badger 23/24",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Line Honey Badger är en väldigt prisvärd skida för dig som vill kunna köra park men samtidigt kunna ta dig över hela berget.",
                LongDescription = "Line Honey Badger är en väldigt prisvärd skida för dig som vill kunna köra park men samtidigt kunna ta dig över hela berget. Skidan är konstruerad med en träkärna av asp och faner vilket bidrar till en poppig känsla.",
                Price = 3995m,
                StockQuantity = 25,
                Brand = "Line",
                CategoryId = 10,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Deacon 76 Black RMotion 23/24",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Völkl Deacon 76 är en riktigt grym pistskida med race-karaktär.",
                LongDescription = "Völkl Deacon 76 är en riktigt grym pistskida med race-karaktär. Kanske det optimala valet för dig som vill ta din åkning till nästa nivå och utveckla din teknik i pisten utan att gå till en renodlad race-skida.",
                Price = 10995m,
                StockQuantity = 3,
                Brand = "Völkl",
                CategoryId = 11,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Black Pearl 82 23/24",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Blizzard Black Pearl 82 är en lekfull och kvick skida som utan att bli instabil eller fladdrig hanterar alla typer av pistade snöförhållanden",
                LongDescription = "Blizzard Black Pearl 82 är en lekfull och kvick skida som utan att bli instabil eller fladdrig hanterar alla typer av pistade snöförhållanden. För dig som åker i första hand pist och vill ha något som funkar både för nypistade morgonåk och uppåkta eftermiddagspucklar är den kanon!",
                Price = 5995m,
                StockQuantity = 16,
                Brand = "Blizzard",
                CategoryId = 11,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Method B&E",
                ProductId = Guid.NewGuid().ToString(),
                Description = "K2 Method B&E Henke Harlauts promodel pjäxa.",
                LongDescription = "K2 Method B&E Henke Harlauts promodel pjäxa. Med en rymlig läst på 102mm och högt insteg sitter du bekvämt i pjäxan även om du har breda pch höga fötter, och med Pro wrap linern får du en passform utan dess like.",
                Price = 5295m,
                StockQuantity = 38,
                Brand = "K2",
                CategoryId = 12,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "Cabrio LV Free 130",
                ProductId = Guid.NewGuid().ToString(),
                Description = "Dalbello Cabrio Free är en uppdaterad och vidareutvecklad modell som bygger på en omåttligt populära Lupo serien.",
                LongDescription = "Dalbello Cabrio Free är en uppdaterad och vidareutvecklad modell som bygger på en omåttligt populära Lupo serien. Den tredelade konstruktionen ger ett följsamt och proggressivt flex som går både mer retur i pjäxan och en mer skonsam känsla mot smalbenen.",
                Price = 7495m,
                StockQuantity = 35,
                Brand = "Dalbello",
                CategoryId = 13,
                CreatedAt = DateTime.UtcNow
            });

            DbContext.Products.Add(new Product
            {
                Name = "TX Comp",
                ProductId = Guid.NewGuid().ToString(),
                Description = "TX Comp är den styvaste telispjäxan från Scarpa.",
                LongDescription = "TX Comp är den styvaste telispjäxan från Scarpa. Med ett flex som väl matchar vridstyvheten i den superpopulära NTNsystemet är TX Comp utmärkt för den moderna telemarksåkaren som har en kraftfull åkstil.",
                Price = 6395m,
                StockQuantity = 13,
                Brand = "Scarpa",
                CategoryId = 14,
                CreatedAt = DateTime.UtcNow
            });

            return DbContext.SaveChanges();
        }
    }
}