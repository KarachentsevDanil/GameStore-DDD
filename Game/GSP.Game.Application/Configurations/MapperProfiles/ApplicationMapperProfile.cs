using AutoMapper;
using GSP.Game.Application.CQS.Commands.DeveloperStudios;
using GSP.Game.Application.CQS.Commands.Genres;
using GSP.Game.Application.CQS.Commands.Publishers;
using GSP.Game.Application.UseCases.DTOs.DeveloperStudios;
using GSP.Game.Application.UseCases.DTOs.Genres;
using GSP.Game.Application.UseCases.DTOs.Publishers;
using GSP.Game.Domain.Entities;

namespace GSP.Game.Application.Configurations.MapperProfiles
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<Genre, GetGenreDto>();
            CreateMap<CreateGenreCommand, AddGenreDto>();
            CreateMap<UpdateGenreCommand, UpdateGenreDto>();

            CreateMap<DeveloperStudio, GetDeveloperStudioDto>();
            CreateMap<CreateDeveloperStudioCommand, AddDeveloperStudioDto>();
            CreateMap<UpdateDeveloperStudioCommand, UpdateDeveloperStudioDto>();

            CreateMap<Publisher, GetPublisherDto>();
            CreateMap<CreatePublisherCommand, AddPublisherDto>();
            CreateMap<UpdatePublisherCommand, UpdatePublisherDto>();
        }
    }
}