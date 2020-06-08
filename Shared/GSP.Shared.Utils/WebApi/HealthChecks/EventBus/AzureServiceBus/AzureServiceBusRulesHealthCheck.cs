using Dawn;
using GSP.Shared.Utils.Common.ServiceBus.Base.Configurations;
using GSP.Shared.Utils.Common.ServiceBus.Base.Models;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Management;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.WebApi.HealthChecks.EventBus.AzureServiceBus
{
    public class AzureServiceBusRulesHealthCheck : IHealthCheck
    {
        private readonly AzureServiceBusConfiguration _rulesConfiguration;

        public AzureServiceBusRulesHealthCheck(AzureServiceBusConfiguration rulesConfiguration)
        {
            _rulesConfiguration =
                Guard.Argument(rulesConfiguration, nameof(rulesConfiguration)).NotNull();
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                ServiceBusConnectionStringBuilder connectionStringBuilder =
                    new ServiceBusConnectionStringBuilder(_rulesConfiguration.ConnectionString);

                var managementClient = new ManagementClient(connectionStringBuilder);

                foreach (Topic topic in _rulesConfiguration.Topics)
                {
                    if (!await managementClient.TopicExistsAsync(topic.Name, cancellationToken))
                    {
                        return new HealthCheckResult(
                            context.Registration.FailureStatus,
                            description: $"Topic with name: {topic.Name} doesn't exists.");
                    }

                    connectionStringBuilder.EntityPath = topic.Name;

                    foreach (Subscriber subscriber in topic.Subscribers)
                    {
                        if (!await managementClient.SubscriptionExistsAsync(topic.Name, subscriber.Name, cancellationToken))
                        {
                            return new HealthCheckResult(
                                context.Registration.FailureStatus,
                                description: $"Subscription with name: {subscriber.Name} doesn't exists.");
                        }

                        SubscriptionClient subscriptionClient =
                            new SubscriptionClient(connectionStringBuilder, subscriber.Name);

                        bool allRuleApplied =
                            await CheckRulesAsync(subscriber, subscriptionClient);

                        if (!allRuleApplied)
                        {
                            return new HealthCheckResult(HealthStatus.Unhealthy, "Not all rules were applied");
                        }

                        await subscriptionClient.CloseAsync();
                    }
                }

                await managementClient.CloseAsync();

                return new HealthCheckResult(HealthStatus.Healthy);
            }
            catch (Exception ex)
            {
                return new HealthCheckResult(context.Registration.FailureStatus, exception: ex);
            }
        }

        private static async Task<bool> CheckRulesAsync(
            Subscriber subscriber, SubscriptionClient subscriptionClient)
        {
            IEnumerable<RuleDescription> rules = await subscriptionClient.GetRulesAsync();
            return subscriber.Labels.All(sr => rules.Any(r => r.Name == sr));
        }
    }
}