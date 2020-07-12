using GSP.Payment.Application.CQS.Bus.Constants;
using GSP.Payment.Application.CQS.Bus.Messages;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using System.Threading.Tasks;

namespace GSP.Payment.Application.CQS.Bus
{
    public static class ServiceBusExtensions
    {
        public static async Task PublishOrderPaidAsync(
            this IServiceBusClient serviceBusClient,
            OrderPaidMessage message)
        {
            await serviceBusClient.PublishAsync(
                message,
                PaymentServiceBusConstants.OrderPaidLabel,
                PaymentServiceBusConstants.OrderTopicName);
        }
    }
}