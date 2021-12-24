using Microsoft.EntityFrameworkCore;
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

            var connectionString = configuration.GetConnectionString("MSSQLConnection");

            var optionsBuilder = new DbContextOptionsBuilder<NetCoreDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new NetCoreDbContext(optionsBuilder.Options);
        }
    }
}