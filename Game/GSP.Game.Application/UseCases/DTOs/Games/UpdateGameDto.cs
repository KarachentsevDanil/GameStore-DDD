using GSP.Shared.Utils.Application.UseCases.DTOs;
using System.Collections.Generic;

namespace GSP.Game.Application.UseCases.DTOs.Games
{
    public class UpdateGameDto : BaseUpdateItemDto
    {
        public long GenreId { get; set; }

        public long PublisherId { get; set; }

        public long DeveloperStudioId { get; set; }

        public GameDetailsDto GameDetails { get; set; }

        public ICollection<GameAttachmentDto> Attachments { get; set; }
    }
}