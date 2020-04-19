using GSP.Game.Application.CQS.Queries.DeveloperStudios;
using GSP.Game.Application.UseCases.DTOs.DeveloperStudios;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Handlers.Queries.DeveloperStudios
{
    public class GetDeveloperStudioByIdQueryHandler : BaseResponseHandler<GetDeveloperStudioByIdQuery, GetDeveloperStudioDto>
    {
        private readonly IDeveloperStudioService _developerStudioService;

        public GetDeveloperStudioByIdQueryHandler(
            ILogger<GetDeveloperStudioByIdQuery> logger,
            IDeveloperStudioService developerStudioService)
            : base(logger)
        {
            _developerStudioService = developerStudioService;
        }

        protected override async Task<GetDeveloperStudioDto> ExecuteAsync(GetDeveloperStudioByIdQuery request, CancellationToken ct)
        {
            return await _developerStudioService.GetByIdAsync(request.Id, ct);
        }
    }
}