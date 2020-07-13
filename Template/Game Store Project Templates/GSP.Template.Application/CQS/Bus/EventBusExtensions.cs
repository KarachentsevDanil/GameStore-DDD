using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using GSP.Template.Application.CQS.Bus.Messages;
using System.Threading.Tasks;
using static GSP.Template.Application.CQS.Bus.Constants.TemplateEventBusConstants;

namespace GSP.Template.Application.CQS.Bus
{
    public static class EventBusExtensions
    {
        public static async Task PublishTemplateCreatedAsync(
            this IServiceBusClient serviceBusClient,
            TemplateCreatedMessage template)
        {
            await serviceBusClient.PublishAsync(template, TemplateCreatedLabel, TemplateTopicName);
        }

        public static async Task PublishTemplateUpdatedAsync(
            this IServiceBusClient serviceBusClient,
            TemplateUpdatedMessage template)
        {
            await serviceBusClient.PublishAsync(template, TemplateUpdatedLabel, TemplateTopicName);
        }
    }
}