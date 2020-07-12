using AutoMapper;
using GSP.Payment.Application.Configurations.MapperProfiles;
using GSP.Payment.Application.UseCases.Services;
using GSP.Payment.Application.UseCases.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Payment.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPaymentApplicationLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationProfile));
            serviceCollection.AddScoped<IPaymentHistoryService, PaymentHistoryService>();
            serviceCollection.AddScoped<IPaymentMethodService, PaymentMethodService>();
            return serviceCollection;
        }
    }
}