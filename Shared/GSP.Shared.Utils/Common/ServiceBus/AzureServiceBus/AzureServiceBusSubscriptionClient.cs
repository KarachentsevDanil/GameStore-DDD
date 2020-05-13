using Dawn;
using GSP.Shared.Utils.Common.Extensions;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Configurations;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Contracts;
using GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus.Models;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using GSP.Shared.Utils.Common.ServiceBus.Base.Models;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Polly;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Common.ServiceBus.AzureServiceBus
{
    public class AzureServiceBusSubscriptionClient<TEvent, TEventHandler> : BackgroundService, IServiceBusSubscriptionClient<TEvent, TEventHandler>
        where TEvent : IntegrationEvent
        where TEventHandler : IIntegrationEventHandler<TEvent>
    {
        private readonly ILogger _logger;

        private readonly ISubscriptionClient _subscriptionClient;

        private readonly AzureServiceBusSubscriptionConfiguration _configuration;

        private readonly IServiceProvider _serviceProvider;

        public AzureServiceBusSubscriptionClient(
            IAzureServiceBusPersistentConnection persistentConnection,
            ILogger<AzureServiceBusClient> logger,
            IOptions<AzureServiceBusSubscriptionConfiguration> configuration,
            IServiceProvider serviceProvider,
            IConfiguration globalConfiguration)
        {
            Guard.Argument(persistentConnection, nameof(persistentConnection)).NotNull();
            _serviceProvider = serviceProvider;

            _configuration = Guard.Argument(configuration, nameof(configuration)).NotNull().Value.Value;

            _logger = Guard.Argument(logger, nameof(logger)).NotNull().Value;

            _serviceProvider = Guard.Argument(serviceProvider, nameof(serviceProvider)).NotNull().Value;

            var subscriptionInfo = new AzureSubscriptionClientModel();
            globalConfiguration.Bind(typeof(TEvent).Name, subscriptionInfo);

            _subscriptionClient = persistentConnection.CreateSubscriptionClient(subscriptionInfo.TopicName, subscriptionInfo.SubscriptionName);
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

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await _subscriptionClient.CloseAsync();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(RegisterMessageHandler, stoppingToken);
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var integrationEvent = JsonConvert.DeserializeObject<TEvent>(Encoding.UTF8.GetString(message.Body));

            _logger.LogInformation(
                "Event {Event} has been triggered {EventHandler}, Message: {Message}",
                typeof(TEvent).Name,
                typeof(TEventHandler).Name,
                integrationEvent?.ToJsonString());

            var isSuccess = await ProcessEventAsync(integrationEvent);

            if (isSuccess)
            {
                await _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
            }
            else
            {
                await _subscriptionClient.DeadLetterAsync(message.SystemProperties.LockToken);
            }
        }

        private async Task<bool> ProcessEventAsync(TEvent integrationEvent)
        {
            using (var scopedProvider = _serviceProvider.CreateScope())
            {
                try
                {
                    var eventHandler = scopedProvider.ServiceProvider.GetService<TEventHandler>();
                    var policy = CreateRetryPolicy(integrationEvent);

                    await policy.Execute(async () =>
                    {
                        await eventHandler.Handle(integrationEvent);
                    });
                }
                catch (Exception exception)
                {
                    _logger.LogError(
                        "Error occured while executing {EventHandler} with parameters {Event}, Error Message: {ErrorMessage}",
                        typeof(TEventHandler).Name,
                        integrationEvent.ToJsonString(),
                        exception.ToString());

                    return false;
                }
            }

            return true;
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

        private Polly.Retry.RetryPolicy CreateRetryPolicy(TEvent integrationEvent)
        {
            return Policy.Handle<Exception>()
                .WaitAndRetry(_configuration.MaxRetryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                {
                    _logger.LogWarning(
                        ex,
                        "Could not publish event: {Event} of type {EventType} {Timeout}s ({ExceptionMessage})",
                        integrationEvent.ToJsonString(),
                        typeof(TEvent).Name,
                        $"{time.TotalSeconds:n1}",
                        ex.Message);
                });
        }
    }
}