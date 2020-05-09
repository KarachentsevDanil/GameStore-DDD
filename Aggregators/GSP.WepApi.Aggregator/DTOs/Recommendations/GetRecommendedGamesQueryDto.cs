namespace GSP.WepApi.Aggregator.DTOs.Recommendations
{
    public class GetRecommendedGamesQueryDto
    {
        public long GameId { get; set; }

        public int Take { get; set; }
    }
}