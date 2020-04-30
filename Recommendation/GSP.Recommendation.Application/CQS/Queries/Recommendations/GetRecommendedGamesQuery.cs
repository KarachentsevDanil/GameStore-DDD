using System.Collections.Generic;
using MediatR;

namespace GSP.Recommendation.Application.CQS.Queries.Recommendations
{
    public class GetRecommendedGamesQuery : IRequest<IEnumerable<long>>
    {
        public long GameId { get; set; }

        public long AccountId { get; set; }

        public int Take { get; set; }
    }
}