using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GSP.Shared.Utils.Initialization.EntityFramework
{
    public static class DbContextBuilder
    {
        public static T Build<T>(
            IConfigurationRoot configuration,
            string migrationPath,
            string settingKey)
            where T : DbContext
        {
            DbContextOptionsBuilder<T> builder = new DbContextOptionsBuilder<T>();

            string connectionString = configuration.GetConnectionString(settingKey);

            builder.UseSqlServer(
                connectionString,
                opt => opt.MigrationsAssembly(migrationPath));

            return (T)Activator.CreateInstance(typeof(T), builder.Options);
        }
    }
}