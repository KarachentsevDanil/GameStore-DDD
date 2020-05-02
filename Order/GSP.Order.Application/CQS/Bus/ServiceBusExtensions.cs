using System.Threading.Tasks;
using GSP.Order.Application.CQS.Bus.Constants;
using GSP.Order.Application.CQS.Bus.Messages;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;

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
    }
}