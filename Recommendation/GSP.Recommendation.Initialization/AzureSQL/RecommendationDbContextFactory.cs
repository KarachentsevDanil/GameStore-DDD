using GSP.Recommendation.Data.Context;
using GSP.Shared.Utils.Initialization.Constants;
using GSP.Shared.Utils.Initialization.EntityFramework;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GSP.Recommendation.Initialization.AzureSQL
{
    public class RecommendationDbContextFactory : IDesignTimeDbContextFactory<RecommendationDbContext>
    {
        public RecommendationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = Shared.Utils.Initialization.ConfigurationBuilder
                .Create(Directory.GetCurrentDirectory());

            return DbContextBuilder.Build<RecommendationDbContext>(
                config,
                "GSP.Recommendation.Data.Migrations",
                SettingKeyConstants.AzureSqlConnectionKey);
        }
    }
}