using AutoMapper;
using GSP.Account.Application.CQS.Bus;
using GSP.Account.Application.CQS.Bus.Messages;
using GSP.Account.Domain.Events;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Account.Application.CQS.Handlers.Notifications
{
    public class AccountUpdatedNotificationHandler : BaseNotificationHandler<AccountUpdatedEvent>
    {
        private readonly IMapper _mapper;

        private readonly IServiceBusClient _serviceBusClient;

        public AccountUpdatedNotificationHandler(ILogger<AccountUpdatedEvent> logger, IMapper mapper, IServiceBusClient serviceBusClient)
            : base(logger)
        {
            _mapper = mapper;
            _serviceBusClient = serviceBusClient;
        }

        protected override async Task ExecuteAsync(AccountUpdatedEvent request, CancellationToken ct)
        {
            AccountUpdatedMessage accountUpdatedMessage = _mapper.Map<AccountUpdatedMessage>(request);
            await _serviceBusClient.PublishAccountUpdatedAsync(accountUpdatedMessage);
        }
    }
}