namespace GSP.Recommendation.Application.UseCases.DTOs.Recommendations
{
    public class GetRecommendedGames
    {
        public long AccountId { get; set; }

        public long GameId { get; set; }

        public int Take { get; set; }
    }
}