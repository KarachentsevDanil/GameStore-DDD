using GSP.Game.Application.CQS.Queries.Publishers;
using GSP.Game.Application.UseCases.DTOs.Publishers;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.Models.Collections;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Handlers.Queries.Publishers
{
    public class GetPublisherPagedListQueryHandler
        : BaseResponseHandler<GetPublisherPagedListQuery, PagedCollection<GetPublisherDto>>
    {
        private readonly IPublisherService _service;

        public GetPublisherPagedListQueryHandler(
            ILogger<GetPublisherPagedListQuery> logger,
            IPublisherService service)
            : base(logger)
        {
            _service = service;
        }

        protected override async Task<PagedCollection<GetPublisherDto>> ExecuteAsync(GetPublisherPagedListQuery request, CancellationToken ct)
        {
            return await _service.GetPagedListAsync(request.ToPaginationFilterParams(), ct);
        }
    }
}