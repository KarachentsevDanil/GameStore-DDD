using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Shared.Utils.Application.CQS.Commands;

namespace GSP.Game.Application.CQS.Commands.Games
{
    public class UpdateGameRatingCommand : BaseUpdateItemCommand<GetGameDto>
    {
        public UpdateGameRatingCommand(long id, int reviewsCount, double averageRating)
        {
            Id = id;
            ReviewsCount = reviewsCount;
            AverageRating = averageRating;
        }

        public int ReviewsCount { get; set; }

        public double AverageRating { get; set; }
    }
}