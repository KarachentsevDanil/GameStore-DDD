using GSP.Gateway.Configurations;
using GSP.Shared.Utils.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMLib.Ocelot.Provider.AppConfiguration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace GSP.Gateway.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGspGateway(
            this IServiceCollection services,
            IConfiguration configuration,
            OcelotConfiguration ocelotConfiguration)
        {
            services.AddOcelot()
                .AddAppConfiguration();

            if (ocelotConfiguration.IsOcelotSwaggerEnabled)
            {
                services.AddSwaggerForOcelot(configuration);
            }

            services.AddJwtBearerAuthentication(configuration);

            return services;
        }

        public static IApplicationBuilder UseGspGateway(
            this IApplicationBuilder applicationBuilder,
            OcelotConfiguration ocelotConfiguration)
        {
            if (ocelotConfiguration.IsOcelotSwaggerEnabled)
            {
                applicationBuilder.UseSwaggerForOcelotUI();
            }

            applicationBuilder.UseAuthentication();
            applicationBuilder.UseStaticFiles();
            applicationBuilder.UseOcelot().Wait();

            return applicationBuilder;
        }
    }
}