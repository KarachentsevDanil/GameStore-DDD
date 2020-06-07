using GSP.Shared.Utils.WebApi.ResourceRegistries.Contracts;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Contracts
{
    public interface IEventBusResourceInitialization : IResource
    {
        Task InitializeEventBusAsync(IConfiguration configuration);
    }
}