using GSP.Shared.Utils.Initialization.Constants;
using GSP.Shared.Utils.Initialization.EntityFramework;
using GSP.Template.Data.Context;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GSP.Template.Initialization.AzureSQL
{
    public class TemplateDbContextFactory : IDesignTimeDbContextFactory<TemplateDbContext>
    {
        public TemplateDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = Shared.Utils.Initialization.ConfigurationBuilder
                .Create(Directory.GetCurrentDirectory());

            return DbContextBuilder.Build<TemplateDbContext>(
                config,
                "GSP.Template.Data.Migrations",
                SettingKeyConstants.AzureSqlConnectionKey);
        }
    }
}