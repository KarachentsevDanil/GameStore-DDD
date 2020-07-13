using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using $safeprojectname$.CQS.Bus.Messages;
using System.Threading.Tasks;
using static $safeprojectname$.CQS.Bus.Constants.$domainName$EventBusConstants;

namespace $safeprojectname$.CQS.Bus
{
    public static class EventBusExtensions
    {
        public static async Task Publish$domainName$CreatedAsync(
            this IServiceBusClient serviceBusClient,
            $domainName$CreatedMessage $domainNameLowerTitleCase$)
        {
            await serviceBusClient.PublishAsync($domainNameLowerTitleCase$, $domainName$CreatedLabel, $domainName$TopicName);
        }

        public static async Task Publish$domainName$UpdatedAsync(
            this IServiceBusClient serviceBusClient,
            $domainName$UpdatedMessage $domainNameLowerTitleCase$)
        {
            await serviceBusClient.PublishAsync($domainNameLowerTitleCase$, $domainName$UpdatedLabel, $domainName$TopicName);
        }
    }
}