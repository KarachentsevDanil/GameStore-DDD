using System.Collections.Generic;
using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Game.Application.UseCases.DTOs.Games
{
    public class AddGameDto : BaseAddItemDto
    {
        public long GenreId { get; set; }

        public long PublisherId { get; set; }

        public long DeveloperStudioId { get; set; }

        public GameDetailsDto GameDetails { get; set; }

        public ICollection<GameAttachmentDto> Attachments { get; set; }
    }
}