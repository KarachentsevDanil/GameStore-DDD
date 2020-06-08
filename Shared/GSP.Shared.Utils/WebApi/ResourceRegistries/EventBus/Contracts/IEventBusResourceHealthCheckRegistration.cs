using GSP.Shared.Utils.WebApi.ResourceRegistries.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Contracts
{
    public interface IEventBusResourceHealthCheckRegistration : IResource
    {
        IHealthChecksBuilder AddEventBusHealthCheck(IHealthChecksBuilder healthChecksBuilder, IConfiguration configuration);
    }
}