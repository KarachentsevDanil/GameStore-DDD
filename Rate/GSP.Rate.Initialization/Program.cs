using GSP.Rate.Data.Context;
using GSP.Shared.Utils.Initialization.Constants;
using GSP.Shared.Utils.Initialization.EntityFramework;
using GSP.Shared.Utils.Initialization.EventBus;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using ConfigurationBuilder = GSP.Shared.Utils.Initialization.ConfigurationBuilder;

namespace GSP.Rate.Initialization
{
    public static class Program
    {
        public static async Task Main()
        {
            IConfigurationRoot config = ConfigurationBuilder.Create(Directory.GetCurrentDirectory());

            await EventBusInitializer.InitializeAsync(config);

            await EntityFrameworkInitializer.InitializeAsync<RateDbContext>(
                config,
                "GSP.Rate.Data.Migrations",
                SettingKeyConstants.AzureSqlConnectionKey);
        }
    }
}