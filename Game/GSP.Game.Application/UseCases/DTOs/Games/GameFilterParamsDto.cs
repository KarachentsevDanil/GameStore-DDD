using GSP.Game.Domain.Enums;
using GSP.Shared.Utils.Common.Models.FilterParams;
using System.Collections.Generic;

namespace GSP.Game.Application.UseCases.DTOs.Games
{
    public class GameFilterParamsDto : PaginationFilterParams
    {
        public IEnumerable<long> GenreIds { get; set; }

        public string Term { get; set; }

        public float? StartPrice { get; set; }

        public float? EndPrice { get; set; }

        public GameSortMode SortMode { get; set; }
    }
}