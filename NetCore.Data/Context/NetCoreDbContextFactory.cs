﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace NetCore.Data.Context
{
    public class NetCoreDbContextFactory : IDesignTimeDbContextFactory<NetCoreDbContext>
    {
        public NetCoreDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<NetCoreDbContext>();

            //var connectionString = configuration.GetConnectionString("MSSQLConnection");
            //optionsBuilder.UseSqlServer(connectionString);

            var connectionString = configuration.GetConnectionString("PostgreSQLConnection");
            optionsBuilder.UseNpgsql(connectionString);

            return new NetCoreDbContext(optionsBuilder.Options);
        }
    }
}