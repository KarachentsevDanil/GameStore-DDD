using AutoMapper;
using FluentValidation;
using GSP.Game.Application.Configurations.MapperProfiles;
using GSP.Game.Application.CQS.Commands.DeveloperStudios;
using GSP.Game.Application.CQS.Commands.Games;
using GSP.Game.Application.CQS.Commands.Genres;
using GSP.Game.Application.CQS.Commands.Publishers;
using GSP.Game.Application.CQS.Handlers.Commands.Games;
using GSP.Game.Application.CQS.Validations.DeveloperStudios;
using GSP.Game.Application.CQS.Validations.Games;
using GSP.Game.Application.CQS.Validations.Genres;
using GSP.Game.Application.CQS.Validations.Publishers;
using GSP.Game.Application.UseCases.Services;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Game.Data.UnitOfWorks;
using GSP.Game.Domain.UnitOfWorks.Contracts;
using GSP.Game.Worker.Configurations.MapperProfiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Game.Worker.Extensions
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
            serviceCollection.AddAutoMapper(typeof(ApplicationMapperProfile), typeof(WorkerProfile));
            serviceCollection.AddScoped<IGenreService, GenreService>();
            serviceCollection.AddScoped<IDeveloperStudioService, DeveloperStudioService>();
            serviceCollection.AddScoped<IPublisherService, PublisherService>();
            serviceCollection.AddScoped<IGameService, GameService>();

            serviceCollection.AddMediatR(typeof(UpdateGameRatingCommandHandler).Assembly);

            serviceCollection.AddSingleton<IValidator<CreateGameCommand>, AddGameValidator>();
            serviceCollection.AddSingleton<IValidator<UpdateGameCommand>, UpdateGameValidator>();

            serviceCollection.AddSingleton<IValidator<CreateGenreCommand>, CreateGenreValidator>();
            serviceCollection.AddSingleton<IValidator<UpdateGenreCommand>, UpdateGenreValidator>();

            serviceCollection.AddSingleton<IValidator<CreatePublisherCommand>, CreatePublisherValidator>();
            serviceCollection.AddSingleton<IValidator<UpdatePublisherCommand>, UpdatePublisherValidator>();

            serviceCollection.AddSingleton<IValidator<CreateDeveloperStudioCommand>, CreateDeveloperStudioValidator>();
            serviceCollection.AddSingleton<IValidator<UpdateDeveloperStudioCommand>, UpdateDeveloperStudioValidator>();

            return serviceCollection;
        }
    }
}