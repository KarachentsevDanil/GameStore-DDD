using GSP.Shared.Utils.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace GSP.Shared.Utils.Initialization.EntityFramework
{
    public static class DbContextBuilder
    {
        public static T Build<T>(
            IConfigurationRoot configuration,
            string migrationPath,
            string settingKey)
            where T : GspDbContext
        {
            DbContextOptionsBuilder<T> builder = new DbContextOptionsBuilder<T>();

            string connectionString = configuration.GetConnectionString(settingKey);

            builder.UseSqlServer(
                connectionString,
                opt => opt.MigrationsAssembly(migrationPath));

            return (T)Activator.CreateInstance(typeof(T), builder.Options, null, null);
        }
    }
}