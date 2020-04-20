using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Shared.Utils.Application.CQS.Commands;

namespace GSP.Game.Application.CQS.Commands.Games
{
    public class UpdateGameRatingCommand : BaseUpdateItemCommand<GetGameDto>
    {
        public int ReviewsCount { get; set; }

        public double AverageRating { get; set; }
    }
}