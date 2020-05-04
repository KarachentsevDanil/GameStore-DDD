using AutoMapper;
using GSP.Game.Application.CQS.Bus;
using GSP.Game.Application.CQS.Bus.Messages;
using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Game.Domain.Events;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Handlers.Notifications.Games
{
    public class GameUpdatedNotificationHandler : BaseNotificationHandler<GameUpdatedEvent>
    {
        private readonly IMapper _mapper;

        private readonly IServiceBusClient _serviceBusClient;

        public GameUpdatedNotificationHandler(ILogger<GameUpdatedEvent> logger, IMapper mapper, IServiceBusClient serviceBusClient)
            : base(logger)
        {
            _mapper = mapper;
            _serviceBusClient = serviceBusClient;
        }

        protected override async Task ExecuteAsync(GameUpdatedEvent request, CancellationToken ct)
        {
            GameUpdatedMessage gameUpdatedMessage = _mapper.Map<GameUpdatedMessage>(request);
            await _serviceBusClient.PublishGameUpdatedAsync(gameUpdatedMessage);
        }
    }
}