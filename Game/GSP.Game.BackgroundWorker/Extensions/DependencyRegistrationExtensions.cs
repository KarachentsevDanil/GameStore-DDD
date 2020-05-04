﻿using AutoMapper;
using FluentValidation;
using GSP.Game.Application.Configurations.MapperProfiles;
using GSP.Game.Application.CQS.Commands.DeveloperStudios;
using GSP.Game.Application.CQS.Commands.Games;
using GSP.Game.Application.CQS.Commands.Genres;
using GSP.Game.Application.CQS.Commands.Publishers;
using GSP.Game.Application.CQS.Validations.DeveloperStudios;
using GSP.Game.Application.CQS.Validations.Games;
using GSP.Game.Application.CQS.Validations.Genres;
using GSP.Game.Application.CQS.Validations.Publishers;
using GSP.Game.Application.UseCases.Services;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Game.BackgroundWorker.EventHandlers.Games;
using GSP.Game.BackgroundWorker.Events.Games;
using GSP.Game.Data.UnitOfWorks;
using GSP.Game.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Game.BackgroundWorker.Extensions
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
            serviceCollection.AddMediatR(typeof(CreateGameCommand).Assembly);

            serviceCollection.AddAutoMapper(typeof(ApplicationMapperProfile));

            serviceCollection.AddScoped<IGameService, GameService>();
            serviceCollection.AddScoped<IGenreService, GenreService>();
            serviceCollection.AddScoped<IPublisherService, PublisherService>();
            serviceCollection.AddScoped<IDeveloperStudioService, DeveloperStudioService>();

            serviceCollection.AddScoped<IIntegrationEventHandler<GameOrderCountUpdatedEvent>, GameOrderCountUpdatedEventHandler>();
            serviceCollection.AddScoped<IIntegrationEventHandler<GameRatingUpdatedEvent>, GameRatingUpdatedEventHandler>();

            serviceCollection.AddSingleton<IValidator<CreateGameCommand>, AddGameValidator>();
            serviceCollection.AddSingleton<IValidator<UpdateGameCommand>, UpdateGameValidator>();
            serviceCollection.AddSingleton<IValidator<CreateDeveloperStudioCommand>, CreateDeveloperStudioValidator>();
            serviceCollection.AddSingleton<IValidator<UpdateDeveloperStudioCommand>, UpdateDeveloperStudioValidator>();
            serviceCollection.AddSingleton<IValidator<CreateGenreCommand>, CreateGenreValidator>();
            serviceCollection.AddSingleton<IValidator<UpdateGenreCommand>, UpdateGenreValidator>();
            serviceCollection.AddSingleton<IValidator<CreatePublisherCommand>, CreatePublisherValidator>();
            serviceCollection.AddSingleton<IValidator<UpdatePublisherCommand>, UpdatePublisherValidator>();

            return serviceCollection;
        }

        public static IServiceCollection RegisterBackgroundWorkerDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHostedService<AzureServiceBusSubscriptionClient<GameOrderCountUpdatedEvent, IIntegrationEventHandler<GameOrderCountUpdatedEvent>>>();
            serviceCollection.AddHostedService<AzureServiceBusSubscriptionClient<GameRatingUpdatedEvent, IIntegrationEventHandler<GameRatingUpdatedEvent>>>();

            return serviceCollection;
        }
    }
}