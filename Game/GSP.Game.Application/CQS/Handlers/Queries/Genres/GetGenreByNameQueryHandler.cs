using GSP.Game.Application.CQS.Queries.Genres;
using GSP.Game.Application.UseCases.DTOs.Genres;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Handlers.Queries.Genres
{
    public class GetGenreByNameQueryHandler : BaseResponseHandler<GetGenreByNameQuery, GetGenreDto>
    {
        private readonly IGenreService _service;

        public GetGenreByNameQueryHandler(
            ILogger<GetGenreByNameQuery> logger,
            IGenreService service)
            : base(logger)
        {
            _service = service;
        }

        protected override async Task<GetGenreDto> ExecuteAsync(GetGenreByNameQuery request, CancellationToken ct)
        {
            return await _service.GetByNameAsync(request.Name, ct);
        }
    }
}