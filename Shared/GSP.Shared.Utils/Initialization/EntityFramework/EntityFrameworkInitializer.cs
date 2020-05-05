using GSP.Shared.Utils.Data.Context;
using GSP.Shared.Utils.Initialization.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Initialization.EntityFramework
{
    public static class EntityFrameworkInitializer
    {
        public static async Task InitializeAsync<T>(
            IConfigurationRoot config,
            string migrationPath,
            string connectionKey = InitializationConstants.AzureSqlConnectionKey,
            Func<T, Task> additionalMigration = default)
            where T : GspDbContext
        {
            Console.WriteLine("Start migration...");

            try
            {
                await using (T context = DbContextBuilder.Build<T>(config, migrationPath, connectionKey))
                {
                    await context.Database.MigrateAsync();
                    await context.Database.EnsureCreatedAsync();

                    if (additionalMigration != default)
                    {
                        await additionalMigration(context);
                    }
                }

                Console.WriteLine("End migration...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}