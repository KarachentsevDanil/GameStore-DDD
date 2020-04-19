using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Game.Application.UseCases.DTOs.Games
{
    public class UpdateGameRatingDto : BaseUpdateItemDto
    {
        public int ReviewsCount { get; set; }

        public double AverageRating { get; set; }
    }
}