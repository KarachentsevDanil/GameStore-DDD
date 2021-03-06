﻿using GSP.Game.Application.UseCases.DTOs.Genres;
using GSP.Shared.Utils.Application.CQS.Commands;

namespace GSP.Game.Application.CQS.Commands.Genres
{
    public class UpdateGenreCommand : BaseUpdateItemCommand<GetGenreDto>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}