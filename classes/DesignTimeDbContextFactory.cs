using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace _34221700_Project2_CMPG323.Models
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<NWUDATABASEContext>
    {
        public NWUDATABASEContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<NWUDATABASEContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ConnStr"));

            return new NWUDATABASEContext(optionsBuilder.Options);
        }
    }
}
