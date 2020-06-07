using GSP.Shared.Utils.WebApi.ResourceRegistries.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Utils.WebApi.ResourceRegistries.Cache.Contracts
{
    public interface ICacheResourceRegistration : IResource
    {
        void AddCache(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}