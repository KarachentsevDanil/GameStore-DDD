using GSP.Shared.Utils.Common.ServiceBus.Configurations;
using GSP.Shared.Utils.Initialization.Constants;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Initialization.ServiceBus
{
    public static class ServiceBusInitializer
    {
        public static async Task InitializeAsync(
            IConfigurationRoot configuration,
            string sectionName = SettingKeyConstants.ServiceBusConfigurationKey)
        {
            Console.WriteLine("Start Azure Service Bus initialization....");

            AzureServiceBusConfiguration azureServiceBusConfiguration = new AzureServiceBusConfiguration();

            configuration
                .GetSection(sectionName)
                .Bind(azureServiceBusConfiguration);

            await ServiceBusSubscriber.AddRulesAsync(azureServiceBusConfiguration);

            Console.WriteLine("End Azure Service Bus initialization....");
        }
    }
}