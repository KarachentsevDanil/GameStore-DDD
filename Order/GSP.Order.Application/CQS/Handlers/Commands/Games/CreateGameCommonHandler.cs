using AutoMapper;
using GSP.Order.Application.CQS.Commands.Games;
using GSP.Order.Application.UseCases.DTOs.Games;
using GSP.Order.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Application.CQS.Handlers.Commands.Games
{
    public class CreateGameCommonHandler : BaseResponseHandler<CreateGameCommand, GetGameDto>
    {
        private readonly IMapper _mapper;

        private readonly IGameService _gameService;

        public CreateGameCommonHandler(
            ILogger<CreateGameCommand> logger,
            IMapper mapper,
            IGameService gameService)
            : base(logger)
        {
            _mapper = mapper;
            _gameService = gameService;
        }

        protected override async Task<GetGameDto> ExecuteAsync(CreateGameCommand request, CancellationToken ct)
        {
            AddGameDto accountDto = _mapper.Map<AddGameDto>(request);
            return await _gameService.AddAsync(accountDto, ct);
        }
    }
}