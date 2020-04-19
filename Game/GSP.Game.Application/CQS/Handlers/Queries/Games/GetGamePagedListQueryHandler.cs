using AutoMapper;
using GSP.Game.Application.CQS.Queries.Games;
using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.Models.Collections;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Handlers.Queries.Games
{
    public class GetGamePagedListQueryHandler
        : BaseResponseHandler<GetGamePagedListQuery, PagedCollection<GetGameDto>>
    {
        private readonly IGameService _service;

        private readonly IMapper _mapper;

        public GetGamePagedListQueryHandler(
            ILogger<GetGamePagedListQuery> logger,
            IGameService service,
            IMapper mapper)
            : base(logger)
        {
            _service = service;
            _mapper = mapper;
        }

        protected override async Task<PagedCollection<GetGameDto>> ExecuteAsync(GetGamePagedListQuery request, CancellationToken ct)
        {
            return await _service.GetPagedListAsync(_mapper.Map<GameFilterParamsDto>(request), ct);
        }
    }
}