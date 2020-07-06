using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Template.Application.CQS.Queries.Templates;
using GSP.Template.Application.UseCases.DTOs.Templates;
using GSP.Template.Application.UseCases.Services.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Template.Application.CQS.Handlers.Queries.Templates
{
    public class GetTemplateByIdQueryHandler : BaseResponseHandler<GetTemplateByIdQuery, GetTemplateDto>
    {
        private readonly ITemplateService _templateService;

        public GetTemplateByIdQueryHandler(
            ILogger<GetTemplateByIdQuery> logger, ITemplateService templateService)
            : base(logger)
        {
            _templateService = templateService;
        }

        protected override async Task<GetTemplateDto> ExecuteAsync(GetTemplateByIdQuery request, CancellationToken ct)
        {
            return await _templateService.GetByIdAsync(request.Id, ct);
        }
    }
}