using Dawn;
using GSP.Shared.Utils.Common.Extensions;
using GSP.Shared.Utils.Common.ServiceBus.Contracts;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus
{
    public class ServiceBusClient : IServiceBusClient
    {
        private readonly IServiceBusPersistentConnection _persistentConnection;

        private readonly ILogger _logger;

        public ServiceBusClient(
            IServiceBusPersistentConnection persistentConnection,
            ILogger<ServiceBusClient> logger)
        {
            _persistentConnection = Guard.Argument(persistentConnection, nameof(persistentConnection))
                .NotNull()
                .Value;

            _logger = Guard.Argument(logger, nameof(logger))
                .NotNull()
                .Value;
        }

        /// <summary>
        /// Publishes an event of <typeparamref name="T"/> to the Azure Service Bus
        /// </summary>
        /// <typeparam name="T">Type of an event</typeparam>
        /// <param name="busEvent"></param>
        /// <param name="topicName"></param>
        /// <exception cref="System.ArgumentNullException">When 'topicName' is null</exception>
        /// <exception cref="System.ArgumentException">When 'topicName' is empty</exception>
        public async Task PublishAsync<T>(T busEvent, string topicName)
        {
            await PublishAsync(busEvent, null, topicName);
        }

        /// <summary>
        /// Publishes an event of <typeparamref name="T"/> to the Service Bus
        /// </summary>
        /// <typeparam name="T">Type of an event</typeparam>
        /// <param name="busEvent">Event which will be sent to the service bus</param>
        /// <param name="label">Label which will be added to a message</param>
        /// <param name="topicName">Topic name</param>
        /// <exception cref="System.ArgumentNullException">When 'topicName' is null</exception>
        /// <exception cref="System.ArgumentException">When 'topicName' is empty</exception>
        public async Task PublishAsync<T>(T busEvent, string label, string topicName)
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