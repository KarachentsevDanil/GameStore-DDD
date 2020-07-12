using GSP.Shared.Utils.Common.EventBus.Base.Configurations;
using GSP.Shared.Utils.Common.EventBus.Base.Models;
using GSP.Shared.Utils.Initialization.Constants;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Attributes;
using GSP.Shared.Utils.WebApi.ResourceRegistries.Enums;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Contracts;
using GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.Enums;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.WebApi.ResourceRegistries.EventBus.AzureServiceBus
{
    [ResourceMap(nameof(ResourceType.EventBus), nameof(EventBusType.AzureServiceBus))]
    public class AzureServiceBusResourceInitialization : IEventBusResourceInitialization
    {
        public async Task InitializeEventBusAsync(IConfiguration configuration)
        {
            AzureServiceBusConfiguration azureAzureServiceBusConfiguration = new AzureServiceBusConfiguration();

            configuration
                .GetSection(SettingKeyConstants.ServiceBusConfigurationKey)
                .Bind(azureAzureServiceBusConfiguration);

            ServiceBusConnectionStringBuilder connectionStringBuilder =
                new ServiceBusConnectionStringBuilder(azureAzureServiceBusConfiguration.ConnectionString);

            foreach (Topic topic in azureAzureServiceBusConfiguration.Topics)
            {
                Console.WriteLine($"Topic: {topic.Name}. Start");

                connectionStringBuilder.EntityPath = topic.Name;

                foreach (Subscriber subscriber in topic.Subscribers)
                {
                    Console.WriteLine($"Subscriber: {subscriber.Name}. Start");

                    SubscriptionClient subscriptionClient =
                        new SubscriptionClient(connectionStringBuilder, subscriber.Name);

                    await AddRules(subscriber, subscriptionClient);

                    Console.WriteLine($"Subscriber: {subscriber.Name}. End");

                    await subscriptionClient.CloseAsync();
                }

                Console.WriteLine($"Topic: {topic.Name}. End");
            }
        }

        private static async Task AddRules(Subscriber subscriber, SubscriptionClient subscriptionClient)
        {
            foreach (string label in subscriber.Labels)
            {
                RuleDescription ruleDescription = new RuleDescription
                {
                    Name = label,
                    Filter = new CorrelationFilter { Label = label }
                };

                try
                {
                    await RemoveDefaultRuleAsync(subscriptionClient);

                    Console.WriteLine(
                        $"Trying to add the following rule: Name: {label}, Label: {label}");

                    await subscriptionClient.AddRuleAsync(ruleDescription);

                    Console.WriteLine("Rule was successfully added");
                }
                catch (ServiceBusException e)
                    when (e.Message != null && e.Message.Contains("already exists", StringComparison.InvariantCulture))
                {
                    Console.WriteLine("The rule already exists");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Some error occurred: {e.Message}");
                    throw;
                }
            }
        }

        private static async Task RemoveDefaultRuleAsync(ISubscriptionClient subscriptionClient)
        {
            try
            {
                await subscriptionClient.RemoveRuleAsync(RuleDescription.DefaultRuleName);
            }
            catch (MessagingEntityNotFoundException)
            {
                Console.WriteLine("Default rule does not exist.");
            }
        }
    }
}