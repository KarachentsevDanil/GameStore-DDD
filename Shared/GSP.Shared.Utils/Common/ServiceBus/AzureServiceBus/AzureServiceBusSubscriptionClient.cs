using Dawn;
using GSP.Shared.Utils.Common.Extensions;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Configurations;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Contracts;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using GSP.Shared.Utils.Common.ServiceBus.Base.Models;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus
{
    public class AzureServiceBusSubscriptionClient<TEvent, TEventHandler> : IServiceBusSubscriptionClient<TEvent, TEventHandler>
        where TEvent : IntegrationEvent
        where TEventHandler : IIntegrationEventHandler<TEvent>
    {
        private readonly ILogger _logger;

        private readonly ISubscriptionClient _subscriptionClient;

        private readonly AzureServiceBusSubscriptionConfiguration _configuration;

        private TEventHandler _eventHandler;

        public AzureServiceBusSubscriptionClient(
            IAzureServiceBusPersistentConnection persistentConnection,
            ILogger<AzureServiceBusClient> logger,
            string topicName,
            string subscriptionName,
            AzureServiceBusSubscriptionConfiguration configuration,
            TEventHandler eventHandler)
        {
            Guard.Argument(topicName, nameof(topicName)).NotNull();

            Guard.Argument(subscriptionName, nameof(subscriptionName)).NotNull();

            Guard.Argument(persistentConnection, nameof(persistentConnection)).NotNull();

            _eventHandler = eventHandler;

            _configuration = Guard.Argument(configuration, nameof(configuration)).NotNull().Value;

            _logger = Guard.Argument(logger, nameof(logger)).NotNull().Value;

            _subscriptionClient = persistentConnection.CreateSubscriptionClient(topicName, subscriptionName);
        }

        /// <summary>
        /// Register event handler
        /// </summary>
        public void RegisterMessageHandler()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = _configuration.MaxConcurrentCalls,
                AutoComplete = _configuration.MessageAutoComplete
            };

            _subscriptionClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            var integrationEvent = JsonConvert.DeserializeObject<TEvent>(Encoding.UTF8.GetString(message.Body));

            _logger.LogInformation(
                "Event {Event} has been triggered {EventHandler}, Message: {Message}",
                nameof(TEvent),
                nameof(TEventHandler),
                integrationEvent?.ToJsonString());

            await _eventHandler.Handle(integrationEvent);

            await _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            _logger.LogError(exceptionReceivedEventArgs.Exception, "Message handler encountered an exception");

            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;

            _logger.LogDebug($"- Endpoint: {context.Endpoint}");
            _logger.LogDebug($"- Entity Path: {context.EntityPath}");
            _logger.LogDebug($"- Executing Action: {context.Action}");

            return Task.CompletedTask;
        }
    }
}