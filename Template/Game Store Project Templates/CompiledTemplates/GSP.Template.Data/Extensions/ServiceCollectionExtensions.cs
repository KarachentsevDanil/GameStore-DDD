using GSP.Shared.Utils.WebApi.Extensions;
using $safeprojectname$.Context;
using $safeprojectname$.UnitOfWorks;
using GSP.$projectPlainName$.Domain.UnitOfWorks.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Add$domainName$DataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.ConfigureDatabase<$domainName$DbContext>(configuration);
            serviceCollection.AddScoped<I$domainName$UnitOfWork, $domainName$UnitOfWork>();
            return serviceCollection;
        }
    }
}