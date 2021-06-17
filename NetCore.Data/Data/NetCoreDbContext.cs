using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

using NetCore.Data.Models;
using NetCore.Data.Configurations;
using NetCore.Data.Extensions;

namespace NetCore.Data.Data
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

        public DbSet<User> Users { get; set; }
    }
}
