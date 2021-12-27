using Microsoft.EntityFrameworkCore;
using NetCore.Data.Configurations;
using NetCore.Data.Entities;
using NetCore.Data.Extensions;

namespace NetCore.Data.Context
{
    public class NetCoreDbContext : DbContext
    {
        public NetCoreDbContext(DbContextOptions<NetCoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure using Fluent API
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            // Data seeding
            modelBuilder.Seed();
        }

        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductInCategory> ProductInCategories { set; get; }
        public DbSet<User> Users { set; get; }
    }
}