using AzureFromTheTrenches.Commanding.Abstractions;

namespace GSP.Recommendation.Worker.Commands
{
    public class GameRatingUpdatedCommand : ICommand
    {
        public long GameId { get; set; }

        public int CountOfReviews { get; set; }

        public double AverageRating { get; set; }
    }
}