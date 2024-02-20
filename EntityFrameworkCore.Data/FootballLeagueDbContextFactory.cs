using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkCore.Data
{
    public class FootballLeagueDbContextFactory : IDesignTimeDbContextFactory<FootballLeageDbContext>
    {
        public FootballLeageDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                                         .AddJsonFile("appsettings.json")
                                                                         .Build();

            var connectionString = configuration.GetConnectionString("SqlDatabaseConnectionString");
            var optionsBuilder = new DbContextOptionsBuilder<FootballLeageDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new FootballLeageDbContext(optionsBuilder.Options);
        }
    }
}
