using GSP.Rate.Application.CQS.Bus.Constants;
using GSP.Rate.Application.CQS.Bus.Messages;
using GSP.Shared.Utils.Common.ServiceBus.Contracts;
using System.Threading.Tasks;

namespace GSP.Rate.Application.CQS.Bus
{
    public static class ServiceBusExtensions
    {
        public static async Task PublishGameRatingUpdatedAsync(
            this IServiceBusClient serviceBusClient,
            GameRatingUpdatedMessage gameRating)
        {
            await serviceBusClient.PublishAsync(
                gameRating,
                RateServiceBusConstants.GameRatingUpdatedLabel,
                RateServiceBusConstants.GameTopicName);
        }
    }
}