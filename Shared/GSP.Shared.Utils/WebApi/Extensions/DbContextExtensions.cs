using GSP.Shared.Utils.Data.Context;
using GSP.Shared.Utils.WebApi.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GSP.Shared.Utils.WebApi.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection ConfigureDatabase<TContext>(
            this IServiceCollection services, IConfiguration configuration)
            where TContext : GspDbContext
        {
            var dbConfig = new EntityFrameworkConfiguration();

            configuration.Bind(nameof(EntityFrameworkConfiguration), dbConfig);
            services.AddSingleton(dbConfig);

            services.AddDbContext<TContext>(options =>
                options
                    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                    .UseSqlServer(dbConfig.ConnectionString));

            return services;
        }
    }
}