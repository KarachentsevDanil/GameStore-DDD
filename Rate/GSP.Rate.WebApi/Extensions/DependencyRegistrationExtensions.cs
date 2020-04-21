using AutoMapper;
using GSP.Rate.Application.Configurations.MapperProfiles;
using GSP.Rate.Application.UseCases.Services;
using GSP.Rate.Application.UseCases.Services.Contracts;
using GSP.Rate.Data.UnitOfWorks;
using GSP.Rate.Domain.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Rate.WebApi.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static IServiceCollection RegisterCoreDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRateUnitOfWork, RateUnitOfWork>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationProfile));
            serviceCollection.AddScoped<IAccountService, AccountService>();
            serviceCollection.AddScoped<IRateService, RateService>();
            return serviceCollection;
        }
    }
}