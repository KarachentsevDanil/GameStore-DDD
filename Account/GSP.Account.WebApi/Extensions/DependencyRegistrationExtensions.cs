using AutoMapper;
using GSP.Account.Application.Configurations.MapperProfiles;
using GSP.Account.Application.UseCases.Services;
using GSP.Account.Application.UseCases.Services.Contracts;
using GSP.Account.Data.Context;
using GSP.Account.Data.UnitOfWorks;
using GSP.Account.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.WebApi.Configurations;
using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Account.WebApi.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        private const string AccountMigrationAssemblyName = "GSP.Account.Data.Migrations";

        public static IServiceCollection AddAccountHealthChecks(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddHealthChecks()
                .AddGspDbHealthCheck<AccountDbContext>(configuration, AccountMigrationAssemblyName)
                .AddEventBusCheck(serviceCollection, configuration);

            return serviceCollection;
        }

        public static IServiceCollection RegisterCoreDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAccountUnitOfWork, AccountUnitOfWork>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationMapperProfile));
            serviceCollection.AddScoped<IAccountService, AccountService>();
            return serviceCollection;
        }
    }
}