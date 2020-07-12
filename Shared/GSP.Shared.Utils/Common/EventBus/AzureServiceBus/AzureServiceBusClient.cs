using Dawn;
using GSP.Shared.Utils.Common.EventBus.AzureServiceBus.Contracts;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using GSP.Shared.Utils.Common.EventBus.Base.Models;
using GSP.Shared.Utils.Common.Extensions;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Common.EventBus.AzureServiceBus
{
    public class AzureServiceBusClient : IServiceBusClient
    {
        private readonly IAzureServiceBusPersistentConnection _persistentConnection;

        private readonly ILogger _logger;

        public AzureServiceBusClient(
            IAzureServiceBusPersistentConnection persistentConnection,
            ILogger<AzureServiceBusClient> logger)
        {
            _persistentConnection = Guard.Argument(persistentConnection, nameof(persistentConnection))
                .NotNull()
                .Value;

            _logger = Guard.Argument(logger, nameof(logger))
                .NotNull()
                .Value;
        }

        /// <summary>
        /// Publishes an event of <typeparamref name="TEvent"/> to the Azure Service Bus
        /// </summary>
        /// <typeparam name="TEvent">Type of an event</typeparam>
        /// <param name="busEvent"></param>
        /// <param name="topicName"></param>
        /// <exception cref="System.ArgumentNullException">When 'topicName' is null</exception>
        /// <exception cref="System.ArgumentException">When 'topicName' is empty</exception>
        public async Task PublishAsync<TEvent>(TEvent busEvent, string topicName)
            where TEvent : IntegrationEvent
        {
            await PublishAsync(busEvent, null, topicName);
        }

        /// <summary>
        /// Publishes an event of <typeparamref name="TEvent"/> to the Service Bus
        /// </summary>
        /// <typeparam name="TEvent">Type of an event</typeparam>
        /// <param name="busEvent">Event which will be sent to the service bus</param>
        /// <param name="label">Label which will be added to a message</param>
        /// <param name="topicName">Topic name</param>
        /// <exception cref="System.ArgumentNullException">When 'topicName' is null</exception>
        /// <exception cref="System.ArgumentException">When 'topicName' is empty</exception>
        public async Task PublishAsync<TEvent>(TEvent busEvent, string label, string topicName)
            where TEvent : IntegrationEvent
        {
            _logger.LogInformation(
                "Start sending message to '{TopicName}' topic with '{Label}' label. Data: {Data}",
                topicName,
                label,
                busEvent?.ToJsonString() ?? string.Empty);

            Guard.Argument(topicName, nameof(topicName))
                .NotNull()
                .NotEmpty();

            string jsonMessage = JsonConvert.SerializeObject(busEvent);
            byte[] body = Encoding.UTF8.GetBytes(jsonMessage);

            Message message = new Message(body);

            if (!string.IsNullOrEmpty(label))
            {
                message.Label = label;
            }

            _logger.LogInformation("Create topic client for topic with name = {TopicName}", topicName);

            ITopicClient client = _persistentConnection.CreateTopicClient(topicName);

            _logger.LogInformation("Client for topic with name = {TopicName} has been created.", client.TopicName);

            await client.SendAsync(message);

            _logger.LogInformation(
                "Event (label = '{LabelName}') was sent to the '{TopicName}' topic",
                label,
                client.TopicName);
        }
    }
}