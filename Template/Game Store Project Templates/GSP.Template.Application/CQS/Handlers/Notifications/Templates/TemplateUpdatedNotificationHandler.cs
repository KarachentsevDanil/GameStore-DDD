using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using GSP.Template.Application.CQS.Bus;
using GSP.Template.Application.CQS.Bus.Messages;
using GSP.Template.Domain.Events;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Template.Application.CQS.Handlers.Notifications.Templates
{
    public class TemplateUpdatedNotificationHandler : BaseNotificationHandler<TemplateUpdatedEvent>
    {
        private readonly IServiceBusClient _serviceBusClient;

        public TemplateUpdatedNotificationHandler(
            ILogger<TemplateUpdatedEvent> logger, IServiceBusClient serviceBusClient)
            : base(logger)
        {
            _serviceBusClient = serviceBusClient;
        }

        protected override async Task ExecuteAsync(TemplateUpdatedEvent request, CancellationToken ct)
        {
            await _serviceBusClient.PublishTemplateUpdatedAsync(new TemplateUpdatedMessage(request.Id, request.Name));
        }
    }
}