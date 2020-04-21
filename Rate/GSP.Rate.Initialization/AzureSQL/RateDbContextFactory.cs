using GSP.Rate.Data.Context;
using GSP.Shared.Utils.Initialization.Constants;
using GSP.Shared.Utils.Initialization.EntityFramework;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GSP.Rate.Initialization.AzureSQL
{
    public class RateDbContextFactory : IDesignTimeDbContextFactory<RateDbContext>
    {
        public RateDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = Shared.Utils.Initialization.ConfigurationBuilder
                .Create(Directory.GetCurrentDirectory());

            return DbContextBuilder.Build<RateDbContext>(
                config,
                "GSP.Rate.Data.Migrations",
                SettingKeyConstants.AzureSqlConnectionKey);
        }
    }
}