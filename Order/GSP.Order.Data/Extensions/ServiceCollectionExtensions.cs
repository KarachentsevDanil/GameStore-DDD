using GSP.Order.Data.Context;
using GSP.Order.Data.UnitOfWorks;
using GSP.Order.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.WebApi.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Order.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOrderDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.ConfigureDatabase<OrderDbContext>(configuration);
            serviceCollection.AddScoped<IOrderUnitOfWork, OrderUnitOfWork>();
            return serviceCollection;
        }
    }
}