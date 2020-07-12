using GSP.Payment.Data.Context;
using GSP.Payment.Data.UnitOfWorks;
using GSP.Payment.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.WebApi.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Payment.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPaymentDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.ConfigureDatabase<PaymentDbContext>(configuration);
            serviceCollection.AddScoped<IPaymentUnitOfWork, PaymentUnitOfWork>();
            return serviceCollection;
        }
    }
}