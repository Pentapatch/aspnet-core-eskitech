using Microsoft.EntityFrameworkCore;

namespace Eskitech.Infrastructure.Seeding
{
    public abstract class DataSeedContributor<TDbContext>(TDbContext dbContext)
        where TDbContext : DbContext
    {
        public TDbContext DbContext { get; } = dbContext;

        public abstract void SeedData();
    }
}