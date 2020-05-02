using Dawn;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Contracts;
using Microsoft.Azure.ServiceBus;
using System.Collections.Generic;

namespace GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus
{
    public class AzureServiceBusPersistentConnection : IAzureServiceBusPersistentConnection
    {
        private readonly Dictionary<string, ITopicClient> _topicClients;

        private readonly Dictionary<string, ISubscriptionClient> _subscriptionClients;

        private readonly string _connectionString;

        public AzureServiceBusPersistentConnection(string connectionString)
        {
            _connectionString = Guard.Argument(connectionString, nameof(connectionString))
                .NotNull()
                .NotEmpty()
                .Value;

            _topicClients = new Dictionary<string, ITopicClient>();
        }

        /// <summary>
        /// Creates a topic client
        /// </summary>
        /// <param name="topicName"></param>
        public ITopicClient CreateTopicClient(string topicName)
        {
            if (!_topicClients.ContainsKey(topicName) || _topicClients[topicName].IsClosedOrClosing)
            {
                ITopicClient topicClient = BuildTopicClient(topicName);

                if (_topicClients.ContainsKey(topicName))
                {
                    _topicClients[topicName] = topicClient;
                }
                else
                {
                    _topicClients.Add(topicName, topicClient);
                }
            }

            return _topicClients[topicName];
        }

        public ISubscriptionClient CreateSubscriptionClient(string topicName, string subscriptionName)
        {
            var key = $"{topicName}_{subscriptionName}";

            if (!_subscriptionClients.ContainsKey(key) || _subscriptionClients[key].IsClosedOrClosing)
            {
                ISubscriptionClient subscriptionClient = BuildSubscriptionClient(topicName, subscriptionName);

                if (_subscriptionClients.ContainsKey(key))
                {
                    _subscriptionClients[key] = subscriptionClient;
                }
                else
                {
                    _subscriptionClients.Add(key, subscriptionClient);
                }
            }

            return _subscriptionClients[key];
        }

        private ITopicClient BuildTopicClient(string topicName)
        {
            ServiceBusConnectionStringBuilder builder
                = new ServiceBusConnectionStringBuilder(_connectionString)
                {
                    EntityPath = topicName
                };

            return new TopicClient(builder, RetryPolicy.Default);
        }

        private ISubscriptionClient BuildSubscriptionClient(string topicName, string subscriptionName)
        {
            ServiceBusConnectionStringBuilder builder
                = new ServiceBusConnectionStringBuilder(_connectionString)
                {
                    EntityPath = topicName
                };

            return new SubscriptionClient(builder, subscriptionName, ReceiveMode.PeekLock, RetryPolicy.Default);
        }
    }
}