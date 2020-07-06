using GSP.Shared.Utils.Common.Models.Grids;
using GSP.Template.Domain.Grids;
using MediatR;

namespace GSP.Template.Application.CQS.Queries.Templates
{
    public class GetTemplateGridQuery : IRequest<GridModel>
    {
        public TemplateGrid Grid { get; set; }
    }
}