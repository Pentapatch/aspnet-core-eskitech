using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eskitech.Infrastructure.Seeding
{
    public abstract class DataSeedContributor<TDbContext>(TDbContext dbContext, ILogger<DataSeedContributor<TDbContext>> logger)
        where TDbContext : DbContext
    {
        public TDbContext DbContext { get; } = dbContext;

        protected ILogger<DataSeedContributor<TDbContext>> Logger { get; } = logger;

        public void Contribute()
        {
            var contributorType = GetType().Name;

            try
            {
                Logger.LogInformation("{ContributorName} is given the oppertunity to seed data", contributorType);

                var numberOfSeededItems = SeedData();

                if (numberOfSeededItems <= 0)
                    Logger.LogInformation("{ContributorName} skipped seeding data", contributorType);
                else
                    Logger.LogInformation("{ContributorName} seeded {NumberOfItems} items", contributorType, numberOfSeededItems);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while seeding data with {ContributorName}", contributorType);
            }
        }

        protected abstract int SeedData();
    }
}