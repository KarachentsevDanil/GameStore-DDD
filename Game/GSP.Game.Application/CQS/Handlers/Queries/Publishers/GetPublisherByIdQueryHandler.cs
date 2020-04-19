using GSP.Game.Application.CQS.Queries.Publishers;
using GSP.Game.Application.UseCases.DTOs.Publishers;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Handlers.Queries.Publishers
{
    public class GetPublisherByIdQueryHandler : BaseResponseHandler<GetPublisherByIdQuery, GetPublisherDto>
    {
        private readonly IPublisherService _service;

        public GetPublisherByIdQueryHandler(
            ILogger<GetPublisherByIdQuery> logger,
            IPublisherService service)
            : base(logger)
        {
            _service = service;
        }

        protected override async Task<GetPublisherDto> ExecuteAsync(GetPublisherByIdQuery request, CancellationToken ct)
        {
            return await _service.GetByIdAsync(request.Id, ct);
        }
    }
}