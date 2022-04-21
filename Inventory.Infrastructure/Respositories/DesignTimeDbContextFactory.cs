using System;
using System.IO;
using Inventory.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Inventory.Infrastructure.Respositories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<InventoryDbContext>
    {


        InventoryDbContext IDesignTimeDbContextFactory<InventoryDbContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var builder = new DbContextOptionsBuilder<InventoryDbContext>();
            var connectionString = configuration.GetConnectionString("InventoryConnection");

            builder.UseSqlServer(connectionString);
            return new InventoryDbContext(builder.Options);
        }
    }
}
