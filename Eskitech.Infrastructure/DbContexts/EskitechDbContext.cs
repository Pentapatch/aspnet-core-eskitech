using Microsoft.EntityFrameworkCore;

namespace Eskitech.Infrastructure.DbContexts
{
    public class EskitechDbContext : DbContext
    {
        public EskitechDbContext(DbContextOptions<EskitechDbContext> options) : base(options) { }

        /// <summary>
        /// This constructor is needed for MSTest
        /// </summary>
        public EskitechDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        //public virtual DbSet<Product> Products { get; set; }
    }
}