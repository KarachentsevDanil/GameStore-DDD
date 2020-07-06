using GSP.Shared.Utils.Application.CQS.Commands;
using GSP.Template.Application.UseCases.DTOs.Templates;

namespace GSP.Template.Application.CQS.Commands.Templates
{
    public class UpdateTemplateCommand : BaseUpdateItemCommand<GetTemplateDto>
    {
        public string Name { get; set; }
    }
}