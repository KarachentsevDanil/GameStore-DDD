using GSP.Payment.Data.Context;
using GSP.Shared.Utils.Initialization.Constants;
using GSP.Shared.Utils.Initialization.EntityFramework;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using ConfigurationBuilder = GSP.Shared.Utils.Initialization.ConfigurationBuilder;

namespace GSP.Payment.Initialization
{
    public static class Program
    {
        public static async Task Main()
        {
            IConfigurationRoot config = ConfigurationBuilder.Create(Directory.GetCurrentDirectory());

            await EntityFrameworkInitializer.InitializeAsync<PaymentDbContext>(
                config,
                "GSP.Payment.Data.Migrations",
                SettingKeyConstants.AzureSqlConnectionKey);
        }
    }
}