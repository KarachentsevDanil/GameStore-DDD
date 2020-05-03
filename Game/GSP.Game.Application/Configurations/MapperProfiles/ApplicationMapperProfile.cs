using AutoMapper;
using GSP.Game.Application.CQS.Bus.Messages;
using GSP.Game.Application.CQS.Commands.DeveloperStudios;
using GSP.Game.Application.CQS.Commands.Games;
using GSP.Game.Application.CQS.Commands.Genres;
using GSP.Game.Application.CQS.Commands.Publishers;
using GSP.Game.Application.CQS.Queries.Games;
using GSP.Game.Application.UseCases.DTOs.DeveloperStudios;
using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Game.Application.UseCases.DTOs.Genres;
using GSP.Game.Application.UseCases.DTOs.Publishers;
using GSP.Game.Domain.Entities;
using GSP.Game.Domain.Entities.ValueObjects;
using GSP.Game.Domain.Events;
using GSP.Game.Domain.Models.FilterParams;

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

            CreateMap<GameBase, GetGameDto>();
            CreateMap<GameDetails, GameDetailsDto>();
            CreateMap<GameAttachment, GameAttachmentDto>();
            CreateMap<CreateGameCommand, AddGameDto>();
            CreateMap<UpdateGameCommand, UpdateGameDto>();
            CreateMap<GetGamePagedListQuery, GameFilterParamsDto>();
            CreateMap<GetGameDto, GameCreatedMessage>();
            CreateMap<GameFilterParamsDto, GameFilterParams>();
            CreateMap<GameUpdatedEvent, GameDetailsDto>();
        }
    }
}