using GSP.Recommendation.Data.Context;
using GSP.Shared.Utils.Initialization.AzureServiceBus;
using GSP.Shared.Utils.Initialization.Constants;
using GSP.Shared.Utils.Initialization.EntityFramework;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using ConfigurationBuilder = GSP.Shared.Utils.Initialization.ConfigurationBuilder;

namespace GSP.Recommendation.Initialization
{
    public static class Program
    {
        public static async Task Main()
        {
            IConfigurationRoot config = ConfigurationBuilder.Create(Directory.GetCurrentDirectory());

            await ServiceBusInitializer.InitializeAsync(config);

            await EntityFrameworkInitializer.InitializeAsync<RecommendationDbContext>(
                config,
                "GSP.Recommendation.Data.Migrations",
                SettingKeyConstants.AzureSqlConnectionKey);
        }
    }
}