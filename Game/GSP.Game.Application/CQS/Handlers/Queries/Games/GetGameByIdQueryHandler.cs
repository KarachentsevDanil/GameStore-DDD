using GSP.Game.Application.CQS.Queries.Games;
using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Handlers.Queries.Games
{
    public class GetGameByIdQueryHandler : BaseResponseHandler<GetGameByIdQuery, GetGameDto>
    {
        private readonly IGameService _service;

        public GetGameByIdQueryHandler(
            ILogger<GetGameByIdQuery> logger,
            IGameService service)
            : base(logger)
        {
            _service = service;
        }

        protected override async Task<GetGameDto> ExecuteAsync(GetGameByIdQuery request, CancellationToken ct)
        {
            return await _service.GetByIdAsync(request.Id, ct);
        }
    }
}