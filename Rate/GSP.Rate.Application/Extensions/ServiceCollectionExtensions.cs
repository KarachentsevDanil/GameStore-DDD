using AutoMapper;
using GSP.Rate.Application.Configurations.MapperProfiles;
using GSP.Rate.Application.UseCases.Services;
using GSP.Rate.Application.UseCases.Services.Contracts;
using GSP.Rate.Domain.UnitOfWorks;
using GSP.Shared.Utils.Application.Account.UseCases.Services;
using GSP.Shared.Utils.Application.Account.UseCases.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Rate.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRateApplicationLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationProfile));
            serviceCollection.AddScoped<IAccountService, AccountService<IRateUnitOfWork>>();
            serviceCollection.AddScoped<IRateService, RateService>();
            return serviceCollection;
        }
    }
}