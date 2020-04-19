﻿using AutoMapper;
using GSP.Game.Application.Configurations.MapperProfiles;
using GSP.Game.Application.UseCases.Services;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Game.Data.UnitOfWorks;
using GSP.Game.Domain.UnitOfWorks.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Game.WebApi.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static IServiceCollection RegisterCoreDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IGameUnitOfWork, GameUnitOfWork>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationMapperProfile));
            serviceCollection.AddScoped<IGenreService, GenreService>();
            serviceCollection.AddScoped<IDeveloperStudioService, DeveloperStudioService>();
            serviceCollection.AddScoped<IPublisherService, PublisherService>();
            return serviceCollection;
        }
    }
}