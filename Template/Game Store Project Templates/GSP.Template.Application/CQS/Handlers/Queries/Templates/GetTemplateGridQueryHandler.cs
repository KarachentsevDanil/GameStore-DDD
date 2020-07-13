using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Data.Grid.Models;
using GSP.Template.Application.CQS.Queries.Templates;
using GSP.Template.Application.UseCases.Services.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Template.Application.CQS.Handlers.Queries.Templates
{
    public class GetTemplateGridQueryHandler : BaseResponseHandler<GetTemplateGridQuery, GridModel>
    {
        private readonly ITemplateService _templateService;

        public GetTemplateGridQueryHandler(
            ILogger<GetTemplateGridQuery> logger, ITemplateService templateService)
            : base(logger)
        {
            _templateService = templateService;
        }

        protected override async Task<GridModel> ExecuteAsync(GetTemplateGridQuery request, CancellationToken ct)
        {
            return await _templateService.GetGridAsync(request.Grid, ct);
        }
    }
}