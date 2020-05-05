using GSP.Order.Application.CQS.Cache.Constants;
using GSP.Order.Application.CQS.Queries.Games;
using GSP.Order.Application.UseCases.DTOs.Games;
using GSP.Order.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.Cache.Base.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Order.Application.CQS.Handlers.Queries.Games
{
    public class GetGamesByAccountQueryHandler : BaseCachedResponseHandler<GetGamesByAccountQuery, IImmutableList<GetGameDto>>
    {
        private readonly IGameService _gameService;

        public GetGamesByAccountQueryHandler(
            ILogger<GetGamesByAccountQuery> logger,
            ICacheManager cacheManager,
            IGameService gameService)
            : base(logger, cacheManager)
        {
            _gameService = gameService;
        }

        protected override async Task<IImmutableList<GetGameDto>> ExecuteAsync(GetGamesByAccountQuery request, CancellationToken ct)
        {
            return await _gameService.GetGameByAccountIdAsync(request.AccountId, ct);
        }

        protected override string GetCacheKey(GetGamesByAccountQuery request)
        {
            return string.Concat(CacheConstants.AccountGameCacheBucketKey, request.AccountId);
        }
    }
}