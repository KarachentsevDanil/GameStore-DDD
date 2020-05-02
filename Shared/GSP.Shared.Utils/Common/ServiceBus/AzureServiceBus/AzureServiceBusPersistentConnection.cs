using Dawn;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Contracts;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Models;
using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;

namespace GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus
{
    public class AzureServiceBusPersistentConnection : IAzureServiceBusPersistentConnection
    {
        private readonly IDictionary<string, ITopicClient> _topicClients;

        private readonly IDictionary<string, ISubscriptionClient> _subscriptionClients;

        private readonly string _connectionString;

        public AzureServiceBusPersistentConnection(string connectionString)
        {
            _connectionString = Guard.Argument(connectionString, nameof(connectionString))
                .NotNull()
                .NotEmpty()
                .Value;

            _topicClients = new Dictionary<string, ITopicClient>();

            _subscriptionClients = new Dictionary<string, ISubscriptionClient>();
        }

        /// <summary>
        /// Creates a topic client
        /// </summary>
        /// <param name="topicName"></param>
        public ITopicClient CreateTopicClient(string topicName)
        {
            var topicClientMode = new AzureTopicClientModel(topicName);

            return CreateClient(topicName, topicClientMode, _topicClients, BuildTopicClient);
        }

        public ISubscriptionClient CreateSubscriptionClient(string topicName, string subscriptionName)
        {
            var key = $"{topicName}_{subscriptionName}";

            var subscriptionClientModel = new AzureSubscriptionClientModel(topicName, subscriptionName);

            return CreateClient(key, subscriptionClientModel, _subscriptionClients, BuildSubscriptionClient);
        }

        private TClient CreateClient<TClient, TClientModel>(
            string key, TClientModel clientModel, IDictionary<string, TClient> clients, Func<TClientModel, TClient> getClient)
            where TClient : IClientEntity
            where TClientModel : BaseAzureClientModel
        {
            if (!clients.ContainsKey(key) || clients[key].IsClosedOrClosing)
            {
                TClient client = getClient(clientModel);

                if (clients.ContainsKey(key))
                {
                    clients[key] = client;
                }
                else
                {
                    clients.Add(key, client);
                }
            }

            return clients[key];
        }

        private ITopicClient BuildTopicClient(AzureTopicClientModel model)
        {
            ServiceBusConnectionStringBuilder builder
                = new ServiceBusConnectionStringBuilder(_connectionString)
                {
                    EntityPath = model.TopicName
                };

            return new TopicClient(builder, RetryPolicy.Default);
        }

        private ISubscriptionClient BuildSubscriptionClient(AzureSubscriptionClientModel model)
        {
            ServiceBusConnectionStringBuilder builder
                = new ServiceBusConnectionStringBuilder(_connectionString)
                {
                    EntityPath = model.TopicName
                };

            return new SubscriptionClient(builder, model.SubscriptionName, ReceiveMode.PeekLock, RetryPolicy.Default);
        }
    }
}