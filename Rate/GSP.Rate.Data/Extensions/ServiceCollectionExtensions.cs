using GSP.Rate.Data.Context;
using GSP.Rate.Data.UnitOfWorks;
using GSP.Rate.Domain.UnitOfWorks;
using GSP.Shared.Utils.WebApi.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Rate.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRateDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.ConfigureDatabase<RateDbContext>(configuration);
            serviceCollection.AddScoped<IRateUnitOfWork, RateUnitOfWork>();
            return serviceCollection;
        }
    }
}