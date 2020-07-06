using AutoMapper;
using GSP.Template.Application.CQS.Commands.Templates;
using GSP.Template.Application.UseCases.DTOs.Templates;
using GSP.Template.Domain.Entities;

namespace GSP.Template.Application.Configurations.MapperProfiles
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<TemplateBase, GetTemplateDto>();
            CreateMap<AddTemplateCommand, AddTemplateDto>();
            CreateMap<UpdateTemplateCommand, UpdateTemplateDto>();
        }
    }
}