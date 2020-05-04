namespace GSP.Recommendation.Application.UseCases.DTOs.Recommendations
{
    public class GetRecommendedGamesQueryDto
    {
        public long? AccountId { get; set; }

        public long GameId { get; set; }

        public int Take { get; set; }
    }
}