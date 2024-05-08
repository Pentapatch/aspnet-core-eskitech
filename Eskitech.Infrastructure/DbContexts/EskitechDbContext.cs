﻿using Eskitech.Entities.Categories;
using Eskitech.Entities.Products;
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

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
    }
}