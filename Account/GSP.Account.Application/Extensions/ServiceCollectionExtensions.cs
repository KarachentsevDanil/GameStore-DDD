using AutoMapper;
using GSP.Account.Application.Configurations.MapperProfiles;
using GSP.Account.Application.UseCases.Services;
using GSP.Account.Application.UseCases.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Account.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAccountApplicationLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationMapperProfile));
            serviceCollection.AddScoped<IAccountService, AccountService>();
            return serviceCollection;
        }
    }
}