using MediatR;

namespace GSP.Recommendation.Application.CQS.Commands.Games
{
    public class UpdateGameRatingCommand : IRequest
    {
        public UpdateGameRatingCommand(long id, int reviewCount, float averageRating)
        {
            Id = id;
            ReviewCount = reviewCount;
            AverageRating = averageRating;
        }

        public long Id { get; set; }

        public int ReviewCount { get; set; }

        public float AverageRating { get; set; }
    }
}