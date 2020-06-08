using GSP.Shared.Utils.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace GSP.Shared.Utils.Initialization.EntityFramework
{
    public static class DbContextBuilder
    {
        public static TContext Build<TContext>(
            IConfigurationRoot configuration,
            string migrationPath,
            string settingKey)
            where TContext : GspDbContext
        {
            DbContextOptionsBuilder<TContext> builder = new DbContextOptionsBuilder<TContext>();

            string connectionString = configuration.GetConnectionString(settingKey);

            builder.UseSqlServer(
                connectionString,
                opt => opt.MigrationsAssembly(migrationPath));

            return (TContext)Activator.CreateInstance(typeof(TContext), builder.Options, null, null);
        }
    }
}