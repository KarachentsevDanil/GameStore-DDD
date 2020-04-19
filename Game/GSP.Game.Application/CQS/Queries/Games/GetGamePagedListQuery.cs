using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Game.Domain.Enums;
using GSP.Shared.Utils.Application.CQS.Queries;
using System.Collections.Generic;

namespace GSP.Game.Application.CQS.Queries.Games
{
    public class GetGamePagedListQuery : BaseGetPagedListQuery<GetGameDto>
    {
        public IEnumerable<long> GenreIds { get; set; }

        public string Term { get; set; }

        public float? StartPrice { get; set; }

        public float? EndPrice { get; set; }

        public GameSortMode SortMode { get; set; }
    }
}