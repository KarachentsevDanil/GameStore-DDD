using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Game.Application.UseCases.DTOs.Games
{
    public class UpdateGameRatingDto : BaseUpdateItemDto
    {
        public UpdateGameRatingDto(long id, int reviewsCount, double averageRating)
        {
            Id = id;
            ReviewsCount = reviewsCount;
            AverageRating = averageRating;
        }

        public int ReviewsCount { get; set; }

        public double AverageRating { get; set; }
    }
}