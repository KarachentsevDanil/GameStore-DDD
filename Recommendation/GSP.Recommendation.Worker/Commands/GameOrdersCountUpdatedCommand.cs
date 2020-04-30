using AzureFromTheTrenches.Commanding.Abstractions;

namespace GSP.Recommendation.Worker.Commands
{
    public class GameOrdersCountUpdatedCommand : ICommand
    {
        public long GameId { get; set; }

        public int CountOfOrders { get; set; }
    }
}