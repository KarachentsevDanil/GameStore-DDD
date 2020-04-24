using GSP.Payment.Data.Context;
using GSP.Shared.Utils.Initialization.Constants;
using GSP.Shared.Utils.Initialization.EntityFramework;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GSP.Payment.Initialization.AzureSQL
{
    public class PaymentDbContextFactory : IDesignTimeDbContextFactory<PaymentDbContext>
    {
        public PaymentDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = Shared.Utils.Initialization.ConfigurationBuilder
                .Create(Directory.GetCurrentDirectory());

            return DbContextBuilder.Build<PaymentDbContext>(
                config,
                "GSP.Payment.Data.Migrations",
                SettingKeyConstants.AzureSqlConnectionKey);
        }
    }
}