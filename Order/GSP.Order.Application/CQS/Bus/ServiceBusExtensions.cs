using GSP.Order.Application.CQS.Bus.Constants;
using GSP.Order.Application.CQS.Bus.Messages;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using System.Threading.Tasks;

namespace GSP.Order.Application.CQS.Bus
{
    public static class ServiceBusExtensions
    {
        public static async Task PublishGameOrderCountUpdatedAsync(
            this IServiceBusClient serviceBusClient,
            GameOrderCountUpdatedMessage gameRating)
        {
            await serviceBusClient.PublishAsync(
                gameRating,
                OrderServiceBusConstants.GameOrderCountUpdatedLabel,
                OrderServiceBusConstants.GameTopicName);
        }

        public static async Task PublishOrderCompletedAsync(
            this IServiceBusClient serviceBusClient,
            OrderCompletedMessage message)
        {
            await serviceBusClient.PublishAsync(
                message,
                OrderServiceBusConstants.OrderCompletedLabel,
                OrderServiceBusConstants.OrderTopicName);
        }
    }
}