using GSP.Game.Application.CQS.Bus.Constants;
using GSP.Game.Application.CQS.Bus.Messages;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Bus
{
    public static class ServiceBusExtensions
    {
        public static async Task PublishGameCreatedAsync(
            this IServiceBusClient serviceBusClient,
            GameCreatedMessage account)
        {
            await serviceBusClient.PublishAsync(
                account,
                GameServiceBusConstants.GameCreatedLabel,
                GameServiceBusConstants.GameTopicName);
        }

        public static async Task PublishGameUpdatedAsync(
            this IServiceBusClient serviceBusClient,
            GameUpdatedMessage account)
        {
            await serviceBusClient.PublishAsync(
                account,
                GameServiceBusConstants.GameUpdatedLabel,
                GameServiceBusConstants.GameTopicName);
        }
    }
}