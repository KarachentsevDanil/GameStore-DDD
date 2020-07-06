using GSP.Shared.Utils.Application.CQS.Queries;
using GSP.Template.Application.UseCases.DTOs.Templates;

namespace GSP.Template.Application.CQS.Queries.Templates
{
    public class GetTemplateByIdQuery : BaseGetByIdQuery<GetTemplateDto>
    {
        public GetTemplateByIdQuery(long id)
        {
            Id = id;
        }

        public GetTemplateByIdQuery()
        {
        }
    }
}