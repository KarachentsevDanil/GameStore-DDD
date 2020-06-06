using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using GSP.Shared.Utils.Common.ServiceBus.Base.Models;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Common.ServiceBus.Base
{
    public class EventBusSubscriptionClient<TEvent, TEventHandler> : BackgroundService
        where TEvent : IntegrationEvent
        where TEventHandler : IIntegrationEventHandler<TEvent>
    {
        private readonly IServiceBusSubscriptionClient<TEvent, TEventHandler> _subscriptionClient;

        public EventBusSubscriptionClient(IServiceBusSubscriptionClient<TEvent, TEventHandler> subscriptionClient)
        {
            _subscriptionClient = subscriptionClient;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(_subscriptionClient.RegisterMessageHandler, stoppingToken);
        }
    }
}