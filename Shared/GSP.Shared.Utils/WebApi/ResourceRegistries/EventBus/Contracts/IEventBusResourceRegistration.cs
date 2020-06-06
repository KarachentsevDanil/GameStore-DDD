using GSP.Shared.Utils.WebApi.ResourceRegistries.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Contracts
{
    public interface IEventBusResourceRegistration : IResource
    {
        void AddEventBus(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}