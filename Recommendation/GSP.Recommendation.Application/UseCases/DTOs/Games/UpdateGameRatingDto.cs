namespace GSP.Recommendation.Application.UseCases.DTOs.Games
{
    public class UpdateGameRatingDto
    {
        public long GameId { get; set; }

        public long ReviewsCount { get; set; }

        public float AverageRating { get; set; }
    }
}