using System.Collections.Generic;

namespace GSP.WepApi.Aggregator.DTOs.Games
{
    public class GetGameByIdsDto
    {
        public GetGameByIdsDto(IEnumerable<long> ids)
        {
            Ids = ids;
        }

        public IEnumerable<long> Ids { get; set; }
    }
}