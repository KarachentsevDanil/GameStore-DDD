using GSP.Game.Data.Context;
using GSP.Game.Data.UnitOfWorks;
using GSP.Game.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.WebApi.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Game.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGameDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.ConfigureDatabase<GameDbContext>(configuration);
            serviceCollection.AddScoped<IGameUnitOfWork, GameUnitOfWork>();
            return serviceCollection;
        }
    }
}