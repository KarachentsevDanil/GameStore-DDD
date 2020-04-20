using AutoMapper;
using FluentValidation;
using GSP.Game.Application.CQS.Bus;
using GSP.Game.Application.CQS.Bus.Messages;
using GSP.Game.Application.CQS.Commands.Games;
using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.ServiceBus.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Handlers.Commands.Games
{
    public class CreateGameCommandHandler : BaseValidationResponseHandler<CreateGameCommand, GetGameDto>
    {
        private readonly IMapper _mapper;

        private readonly IGameService _service;

        private readonly IServiceBusClient _serviceBusClient;

        public CreateGameCommandHandler(
            IValidator<CreateGameCommand> validator,
            ILogger<CreateGameCommand> logger,
            IMapper mapper,
            IGameService service,
            IServiceBusClient serviceBusClient)
            : base(validator, logger)
        {
            _mapper = mapper;
            _service = service;
            _serviceBusClient = serviceBusClient;
        }

        protected override async Task<GetGameDto> ExecuteAsync(CreateGameCommand request, CancellationToken ct)
        {
            var game = await _service.AddAsync(_mapper.Map<AddGameDto>(request), ct);
            await _serviceBusClient.PublishGameCreatedAsync(_mapper.Map<GameCreatedMessage>(game));
            return game;
        }
    }
}