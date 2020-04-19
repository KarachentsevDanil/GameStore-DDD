using GSP.Game.Application.CQS.Queries.Genres;
using GSP.Game.Application.UseCases.DTOs.Genres;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.Models.Collections;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Handlers.Queries.Genres
{
    public class GetGenrePagedListQueryHandler
        : BaseResponseHandler<GetGenrePagedListQuery, PagedCollection<GetGenreDto>>
    {
        private readonly IGenreService _service;

        public GetGenrePagedListQueryHandler(
            ILogger<GetGenrePagedListQuery> logger,
            IGenreService service)
            : base(logger)
        {
            _service = service;
        }

        protected override async Task<PagedCollection<GetGenreDto>> ExecuteAsync(GetGenrePagedListQuery request, CancellationToken ct)
        {
            return await _service.GetPagedListAsync(request.ToPaginationFilterParams(), ct);
        }
    }
}