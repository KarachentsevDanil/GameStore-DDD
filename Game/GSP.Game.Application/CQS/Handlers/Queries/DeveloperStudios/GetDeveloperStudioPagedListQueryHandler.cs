using GSP.Game.Application.CQS.Queries.DeveloperStudios;
using GSP.Game.Application.UseCases.DTOs.DeveloperStudios;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.Models.Collections;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Handlers.Queries.DeveloperStudios
{
    public class GetDeveloperStudioPagedListQueryHandler
        : BaseResponseHandler<GetDeveloperStudioPagedListQuery, PagedCollection<GetDeveloperStudioDto>>
    {
        private readonly IDeveloperStudioService _developerStudioService;

        public GetDeveloperStudioPagedListQueryHandler(
            ILogger<GetDeveloperStudioPagedListQuery> logger,
            IDeveloperStudioService developerStudioService)
            : base(logger)
        {
            _developerStudioService = developerStudioService;
        }

        protected override async Task<PagedCollection<GetDeveloperStudioDto>> ExecuteAsync(GetDeveloperStudioPagedListQuery request, CancellationToken ct)
        {
            return await _developerStudioService.GetPagedListAsync(request.ToPaginationFilterParams(), ct);
        }
    }
}