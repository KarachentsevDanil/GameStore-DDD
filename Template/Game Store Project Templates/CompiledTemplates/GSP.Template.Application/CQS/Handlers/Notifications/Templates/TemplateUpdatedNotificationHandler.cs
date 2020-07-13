using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using $safeprojectname$.CQS.Bus;
using $safeprojectname$.CQS.Bus.Messages;
using GSP.$projectPlainName$.Domain.Events;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.CQS.Handlers.Notifications.$domainName$s
{
    public class $domainName$UpdatedNotificationHandler : BaseNotificationHandler<$domainName$UpdatedEvent>
    {
        private readonly IServiceBusClient _serviceBusClient;

        public $domainName$UpdatedNotificationHandler(
            ILogger<$domainName$UpdatedEvent> logger, IServiceBusClient serviceBusClient)
            : base(logger)
        {
            _serviceBusClient = serviceBusClient;
        }

        protected override async Task ExecuteAsync($domainName$UpdatedEvent request, CancellationToken ct)
        {
            await _serviceBusClient.Publish$domainName$UpdatedAsync(new $domainName$UpdatedMessage(request.Id, request.Name));
        }
    }
}