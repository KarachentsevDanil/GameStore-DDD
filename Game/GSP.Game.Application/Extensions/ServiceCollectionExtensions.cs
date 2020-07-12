using AutoMapper;
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
using GSP.Game.Domain.Entities;
using GSP.Game.Domain.Grids;
using GSP.Shared.Grid.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GSP.Game.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGameApplicationLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationMapperProfile));
            serviceCollection.AddScoped<IGenreService, GenreService>();
            serviceCollection.AddScoped<IDeveloperStudioService, DeveloperStudioService>();
            serviceCollection.AddScoped<IPublisherService, PublisherService>();
            serviceCollection.AddScoped<IGameService, GameService>();
            serviceCollection.AddGridTypeStore();
            serviceCollection.AddGrid<GameBase, GameGrid>();

            serviceCollection.TryAddSingleton<IValidator<CreateGameCommand>, AddGameValidator>();
            serviceCollection.TryAddSingleton<IValidator<UpdateGameCommand>, UpdateGameValidator>();
            serviceCollection.TryAddSingleton<IValidator<CreateDeveloperStudioCommand>, CreateDeveloperStudioValidator>();
            serviceCollection.TryAddSingleton<IValidator<UpdateDeveloperStudioCommand>, UpdateDeveloperStudioValidator>();
            serviceCollection.TryAddSingleton<IValidator<CreateGenreCommand>, CreateGenreValidator>();
            serviceCollection.TryAddSingleton<IValidator<UpdateGenreCommand>, UpdateGenreValidator>();
            serviceCollection.TryAddSingleton<IValidator<CreatePublisherCommand>, CreatePublisherValidator>();
            serviceCollection.TryAddSingleton<IValidator<UpdatePublisherCommand>, UpdatePublisherValidator>();

            return serviceCollection;
        }
    }
}