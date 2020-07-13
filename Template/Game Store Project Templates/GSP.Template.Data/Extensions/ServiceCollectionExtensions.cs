using GSP.Shared.Utils.WebApi.Extensions;
using GSP.Template.Data.Context;
using GSP.Template.Data.UnitOfWorks;
using GSP.Template.Domain.UnitOfWorks.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Template.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTemplateDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.ConfigureDatabase<TemplateDbContext>(configuration);
            serviceCollection.AddScoped<ITemplateUnitOfWork, TemplateUnitOfWork>();
            return serviceCollection;
        }
    }
}