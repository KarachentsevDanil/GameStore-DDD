using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Shared.Utils.Application.CQS.Commands;
using System.Collections.Generic;

namespace GSP.Game.Application.CQS.Commands.Games
{
    public class CreateGameCommand : BaseCreateItemCommand<GetGameDto>
    {
        public long GenreId { get; set; }

        public long PublisherId { get; set; }

        public long DeveloperStudioId { get; set; }

        public GameDetailsDto GameDetails { get; set; }

        public ICollection<GameAttachmentDto> Attachments { get; set; }
    }
}