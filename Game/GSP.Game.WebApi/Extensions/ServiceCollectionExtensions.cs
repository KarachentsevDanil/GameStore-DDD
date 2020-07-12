using AutoMapper;
using GSP.Game.Application.Configurations.MapperProfiles;
using GSP.Game.Application.UseCases.Services;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Game.Data.Context;
using GSP.Game.Data.UnitOfWorks;
using GSP.Game.Domain.Entities;
using GSP.Game.Domain.Grids;
using GSP.Game.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Utils.WebApi.Configurations;
using GSP.Shared.Utils.WebApi.HealthChecks.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Game.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string GameMigrationAssemblyName = "GSP.Game.Data.Migrations";

        public static IServiceCollection AddGameHealthChecks(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddHealthChecks()
                .AddGspDbHealthCheck<GameDbContext>(configuration, GameMigrationAssemblyName)
                .AddEventBusCheck(serviceCollection, configuration);

            return serviceCollection;
        }
    }
}