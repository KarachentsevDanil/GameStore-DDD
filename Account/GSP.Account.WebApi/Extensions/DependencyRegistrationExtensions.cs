using AutoMapper;
using GSP.Account.Application.Configurations.MapperProfiles;
using GSP.Account.Application.UseCases.Services;
using GSP.Account.Application.UseCases.Services.Contracts;
using GSP.Account.Data.UnitOfWorks;
using GSP.Account.Domain.UnitOfWorks.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Account.WebApi.Extensions
{
    public static class DependencyRegistrationExtensions
    {
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