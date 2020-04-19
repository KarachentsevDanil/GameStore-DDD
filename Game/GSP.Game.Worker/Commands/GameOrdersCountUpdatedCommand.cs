using AzureFromTheTrenches.Commanding.Abstractions;

namespace GSP.Game.Worker.Commands
{
    public class GameOrdersCountUpdatedCommand : ICommand
    {
        public long GameId { get; set; }

        public int CountOfOrders { get; set; }
    }
}