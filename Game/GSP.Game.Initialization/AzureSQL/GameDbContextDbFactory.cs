using GSP.Game.Data.Context;
using GSP.Shared.Utils.Initialization.Constants;
using GSP.Shared.Utils.Initialization.EntityFramework;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GSP.Game.Initialization.AzureSQL
{
    public class GameDbContextDbFactory : IDesignTimeDbContextFactory<GameDbContext>
    {
        public GameDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = Shared.Utils.Initialization.ConfigurationBuilder
                .Create(Directory.GetCurrentDirectory());

            return DbContextBuilder.Build<GameDbContext>(
                config,
                "GSP.Game.Data.Migrations",
                SettingKeyConstants.AzureSqlConnectionKey);
        }
    }
}