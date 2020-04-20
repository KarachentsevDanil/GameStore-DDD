using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus;
using GSP.Shared.Utils.Common.ServiceBus.Constants;
using GSP.Shared.Utils.Common.ServiceBus.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSP.Shared.Utils.Common.ServiceBus.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static string RegisterAzureServiceBus(
            this IServiceCollection services, IConfiguration configuration, string connectionName = ServiceBusConstants.ConnectionName)
        {
            string serviceBusConnection =
                configuration.GetValue<string>(connectionName);

            services.AddSingleton<IServiceBusPersistentConnection>(sp =>
                new ServiceBusPersistentConnection(serviceBusConnection));

            services.AddSingleton<IServiceBusClient, ServiceBusClient>();

            return serviceBusConnection;
        }
    }
}