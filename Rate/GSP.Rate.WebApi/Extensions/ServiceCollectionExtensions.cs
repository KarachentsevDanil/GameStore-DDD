using AutoMapper;
using GSP.Rate.Application.Configurations.MapperProfiles;
using GSP.Rate.Application.UseCases.Services;
using GSP.Rate.Application.UseCases.Services.Contracts;
using GSP.Rate.Data.Context;
using GSP.Rate.Data.UnitOfWorks;
using GSP.Rate.Domain.UnitOfWorks;
using GSP.Shared.Utils.Application.Account.UseCases.Services;
using GSP.Shared.Utils.Application.Account.UseCases.Services.Contracts;
using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Rate.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string RateMigrationAssemblyName = "GSP.Rate.Data.Migrations";

        public static IServiceCollection AddRateHealthChecks(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddHealthChecks()
                .AddGspDbHealthCheck<RateDbContext>(configuration, RateMigrationAssemblyName)
                .AddEventBusCheck(serviceCollection, configuration);

            return serviceCollection;
        }

        public static IServiceCollection RegisterCoreDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRateUnitOfWork, RateUnitOfWork>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationProfile));
            serviceCollection.AddScoped<IAccountService, AccountService<IRateUnitOfWork>>();
            serviceCollection.AddScoped<IRateService, RateService>();
            return serviceCollection;
        }
    }
}