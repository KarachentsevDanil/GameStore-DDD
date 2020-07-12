using AutoMapper;
using GSP.Payment.Application.Configurations.MapperProfiles;
using GSP.Payment.Application.UseCases.Services;
using GSP.Payment.Application.UseCases.Services.Contracts;
using GSP.Payment.Data.Context;
using GSP.Payment.Data.UnitOfWorks;
using GSP.Payment.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Payment.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string PaymentMigrationAssemblyName = "GSP.Payment.Data.Migrations";

        public static IServiceCollection AddPaymentHealthChecks(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddHealthChecks()
                .AddGspDbHealthCheck<PaymentDbContext>(configuration, PaymentMigrationAssemblyName)
                .AddEventBusCheck(serviceCollection, configuration);

            return serviceCollection;
        }
    }
}