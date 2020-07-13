using AutoMapper;
using FluentValidation;
using GSP.Shared.Grid.Extensions;
using $safeprojectname$.Configurations.MapperProfiles;
using $safeprojectname$.CQS.Commands.$domainName$s;
using $safeprojectname$.CQS.Validations.$domainName$s;
using $safeprojectname$.UseCases.Services;
using $safeprojectname$.UseCases.Services.Contracts;
using GSP.$projectPlainName$.Domain.Entities;
using GSP.$projectPlainName$.Domain.Grids;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace $safeprojectname$.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Add$domainName$ApplicationLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationMapperProfile));
            serviceCollection.AddScoped<I$domainName$Service, $domainName$Service>();
            serviceCollection.AddGridTypeStore();
            serviceCollection.AddGrid<$domainName$Base, $domainName$Grid>();
            serviceCollection.TryAddSingleton<IValidator<Add$domainName$Command>, Add$domainName$Validator>();
            serviceCollection.TryAddSingleton<IValidator<Update$domainName$Command>, Update$domainName$Validator>();
            return serviceCollection;
        }
    }
}