using AutoMapper;
using GSP.Payment.Application.Configurations.MapperProfiles;
using GSP.Payment.Application.UseCases.Services;
using GSP.Payment.Application.UseCases.Services.Contracts;
using GSP.Payment.Data.UnitOfWorks;
using GSP.Payment.Domain.UnitOfWorks.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Payment.WebApi.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static IServiceCollection RegisterCoreDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPaymentUnitOfWork, PaymentUnitOfWork>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationProfile));
            serviceCollection.AddScoped<IPaymentHistoryService, PaymentHistoryService>();
            serviceCollection.AddScoped<IPaymentMethodService, PaymentMethodService>();
            return serviceCollection;
        }
    }
}