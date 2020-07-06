using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Template.Application.UseCases.DTOs.Templates
{
    public class AddTemplateDto : BaseAddItemDto
    {
        public string Name { get; set; }
    }
}