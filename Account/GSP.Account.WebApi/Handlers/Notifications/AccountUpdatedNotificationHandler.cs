using AutoMapper;
using GSP.Account.Domain.Events;
using GSP.Account.WebApi.Bus;
using GSP.Account.WebApi.Bus.Messages;
using GSP.Shared.Utils.Common.ServiceBus.Contracts;
using GSP.Shared.Utils.WebApi.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Account.WebApi.Handlers.Notifications
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