using GSP.Game.Domain.Entities;
using GSP.Game.Domain.Enums;
using GSP.Shared.Utils.Common.Models.FilterParams;
using System.Collections.Generic;

namespace GSP.Game.Domain.Models.FilterParams
{
    public class GameFilterParams : BaseExpressionFilterParams<GameBase>
    {
        public IEnumerable<long> GenreIds { get; set; }

        public string Term { get; set; }

        public float? StartPrice { get; set; }

        public float? EndPrice { get; set; }

        public GameSortMode SortMode { get; set; }
    }
}