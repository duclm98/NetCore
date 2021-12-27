using Microsoft.EntityFrameworkCore;
using NetCore.Data.Configurations;
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
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());

            // Data seeding
            modelBuilder.Seed();
        }
    }
}