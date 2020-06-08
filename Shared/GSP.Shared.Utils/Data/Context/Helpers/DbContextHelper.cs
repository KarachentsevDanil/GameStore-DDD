using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GSP.Shared.Utils.Data.Context.Helpers
{
    public static class DbContextHelper
    {
        public static TContext BuildContext<TContext>(
            string connectionString,
            string migrationAssembly)
            where TContext : GspDbContext
        {
            DbContextOptionsBuilder<TContext> builder = new DbContextOptionsBuilder<TContext>();

            builder.UseSqlServer(connectionString, opt => opt.MigrationsAssembly(migrationAssembly));

            return (TContext)Activator.CreateInstance(typeof(TContext), builder.Options, null, null);
        }

        public static string GetLastDbContextMigrationName<TContext>(
            string connectionString,
            string migrationAssembly)
            where TContext : GspDbContext
        {
            using (TContext context = BuildContext<TContext>(connectionString, migrationAssembly))
            {
                IEnumerable<string> migrations = context.Database.GetMigrations();
                return migrations.LastOrDefault();
            }
        }
    }
}