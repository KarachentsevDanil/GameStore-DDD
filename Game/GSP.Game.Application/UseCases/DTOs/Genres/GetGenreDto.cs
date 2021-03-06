﻿using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Game.Application.UseCases.DTOs.Genres
{
    public class GetGenreDto : BaseGetItemDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}