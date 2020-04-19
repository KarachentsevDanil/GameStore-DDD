using GSP.Game.Application.CQS.Queries.Genres;
using GSP.Game.Application.UseCases.DTOs.Genres;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Handlers.Queries.Genres
{
    public class GetGenreByIdQueryHandler : BaseResponseHandler<GetGenreByIdQuery, GetGenreDto>
    {
        private readonly IGenreService _service;

        public GetGenreByIdQueryHandler(
            ILogger<GetGenreByIdQuery> logger,
            IGenreService service)
            : base(logger)
        {
            _service = service;
        }

        protected override async Task<GetGenreDto> ExecuteAsync(GetGenreByIdQuery request, CancellationToken ct)
        {
            return await _service.GetByIdAsync(request.Id, ct);
        }
    }
}