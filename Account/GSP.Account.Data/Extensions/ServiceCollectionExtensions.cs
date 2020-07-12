using GSP.Account.Data.Context;
using GSP.Account.Data.UnitOfWorks;
using GSP.Account.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.WebApi.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Account.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAccountDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.ConfigureDatabase<AccountDbContext>(configuration);
            serviceCollection.AddScoped<IAccountUnitOfWork, AccountUnitOfWork>();
            return serviceCollection;
        }
    }
}