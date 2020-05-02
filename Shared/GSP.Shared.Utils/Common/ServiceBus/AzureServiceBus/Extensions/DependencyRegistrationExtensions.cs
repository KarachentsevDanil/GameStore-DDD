using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Contracts;
using GSP.Shared.Utils.Common.ServiceBus.Base.Constants;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static string RegisterAzureServiceBus(
            this IServiceCollection services, IConfiguration configuration, string connectionName = ServiceBusConstants.ConnectionName)
        {
            string serviceBusConnection =
                configuration.GetValue<string>(connectionName);

            services.AddSingleton<IAzureServiceBusPersistentConnection>(sp =>
                new AzureServiceBusPersistentConnection(serviceBusConnection));

            services.AddSingleton<IServiceBusClient, AzureServiceBusClient>();

            return serviceBusConnection;
        }
    }
}