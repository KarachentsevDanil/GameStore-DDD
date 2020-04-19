using GSP.Game.Application.UseCases.DTOs.DeveloperStudios;
using GSP.Game.Application.UseCases.DTOs.Genres;
using GSP.Game.Application.UseCases.DTOs.Publishers;
using GSP.Shared.Utils.Application.UseCases.DTOs;
using System.Collections.Generic;

namespace GSP.Game.Application.UseCases.DTOs.Games
{
    public class GetGameDto : BaseGetItemDto
    {
        public GetGenreDto Genre { get; set; }

        public GetPublisherDto Publisher { get; set; }

        public GetDeveloperStudioDto DeveloperStudio { get; set; }

        public GameDetailsDto GameDetails { get; set; }

        public ICollection<GameAttachmentDto> Attachments { get; set; }
    }
}