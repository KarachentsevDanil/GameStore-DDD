using GSP.Game.Domain.Enums;
using System;

namespace GSP.Game.Application.UseCases.DTOs.Games
{
    public class GameAttachmentDto
    {
        public AttachmentType Type { get; set; }

        public Uri LinkUri { get; set; }

        public string Description { get; set; }
    }
}