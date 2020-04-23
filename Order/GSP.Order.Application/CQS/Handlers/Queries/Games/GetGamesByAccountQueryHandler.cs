using GSP.Order.Application.CQS.Queries.Games;
using GSP.Order.Application.UseCases.DTOs.Games;
using GSP.Order.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Application.CQS.Handlers.Queries.Games
{
    public class GetGamesByAccountQueryHandler : BaseResponseHandler<GetGamesByAccountQuery, IImmutableList<GetGameDto>>
    {
        private readonly IGameService _gameService;

        public GetGamesByAccountQueryHandler(
            ILogger<GetGamesByAccountQuery> logger,
            IGameService gameService)
            : base(logger)
        {
            _gameService = gameService;
        }

        protected override async Task<IImmutableList<GetGameDto>> ExecuteAsync(GetGamesByAccountQuery request, CancellationToken ct)
        {
            return await _gameService.GetGameByAccountIdAsync(request.AccountId, ct);
        }
    }
}