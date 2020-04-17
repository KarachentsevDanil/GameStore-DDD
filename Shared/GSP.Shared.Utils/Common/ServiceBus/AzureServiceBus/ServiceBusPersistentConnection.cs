using Dawn;
using GSP.Shared.Utils.Common.ServiceBus.Contracts;
using Microsoft.Azure.ServiceBus;
using System.Collections.Generic;

namespace GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus
{
    public class ServiceBusPersistentConnection : IServiceBusPersistentConnection
    {
        private readonly Dictionary<string, ITopicClient> _topicClients;

        private readonly string _connectionString;

        public ServiceBusPersistentConnection(string connectionString)
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

        private ITopicClient BuildTopicClient(string topicName)
        {
            ServiceBusConnectionStringBuilder builder
                = new ServiceBusConnectionStringBuilder(_connectionString)
                {
                    EntityPath = topicName
                };

            return new TopicClient(builder, RetryPolicy.Default);
        }
    }
}