using GSP.Shared.Utils.Common.Sessions;
using GSP.Shared.Utils.Common.Sessions.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Utils.WebApi.Sessions.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGspSession(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IGspSession, GspClaimsSession>();
            serviceCollection.AddScoped<IGspPrincipalAccessor, WebApiPrincipalAccessor>();
            serviceCollection.AddScoped<IGspRequestInfoAccessor, WebApiRequestInfoAccessor>();
            return serviceCollection;
        }
    }
}