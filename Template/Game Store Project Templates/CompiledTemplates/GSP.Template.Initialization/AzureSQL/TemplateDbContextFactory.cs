using GSP.Shared.Utils.Initialization.Constants;
using GSP.Shared.Utils.Initialization.EntityFramework;
using GSP.$projectPlainName$.Data.Context;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace $safeprojectname$.AzureSQL
{
    public class $domainName$DbContextFactory : IDesignTimeDbContextFactory<$domainName$DbContext>
    {
        public $domainName$DbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = Shared.Utils.Initialization.ConfigurationBuilder
                .Create(Directory.GetCurrentDirectory());

            return DbContextBuilder.Build<$domainName$DbContext>(
                config,
                "GSP.$projectPlainName$.Data.Migrations",
                SettingKeyConstants.AzureSqlConnectionKey);
        }
    }
}