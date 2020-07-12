using GSP.Account.Application.CQS.Bus.Constants;
using GSP.Account.Application.CQS.Bus.Messages;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using System.Threading.Tasks;

namespace GSP.Account.Application.CQS.Bus
{
    public static class ServiceBusExtensions
    {
        public static async Task PublishAccountCreatedAsync(
            this IServiceBusClient serviceBusClient,
            AccountCreatedMessage account)
        {
            await serviceBusClient.PublishAsync(
                account,
                AccountServiceBusConstants.AccountCreatedLabel,
                AccountServiceBusConstants.AccountTopicName);
        }

        public static async Task PublishAccountUpdatedAsync(
            this IServiceBusClient serviceBusClient,
            AccountUpdatedMessage account)
        {
            await serviceBusClient.PublishAsync(
                account,
                AccountServiceBusConstants.AccountUpdatedLabel,
                AccountServiceBusConstants.AccountTopicName);
        }
    }
}