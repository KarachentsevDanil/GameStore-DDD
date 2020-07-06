using AutoMapper;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Template.Application.CQS.Queries.Templates;
using GSP.Template.Application.UseCases.DTOs.Templates;
using GSP.Template.Application.UseCases.Services.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Template.Application.CQS.Handlers.Queries.Templates
{
    public class GetTemplatePagedQueryHandler : BaseResponseHandler<GetTemplatePagedQuery, PagedCollection<GetTemplateDto>>
    {
        private readonly ITemplateService _templateService;

        public GetTemplatePagedQueryHandler(
            ILogger<GetTemplatePagedQuery> logger, ITemplateService templateService)
            : base(logger)
        {
            _templateService = templateService;
        }

        protected override async Task<PagedCollection<GetTemplateDto>> ExecuteAsync(GetTemplatePagedQuery request, CancellationToken ct)
        {
            return await _templateService.GetPagedListAsync(request.ToPaginationFilterParams(), ct);
        }
    }
}