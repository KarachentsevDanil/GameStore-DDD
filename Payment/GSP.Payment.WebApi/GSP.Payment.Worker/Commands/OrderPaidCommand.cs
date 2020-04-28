using AzureFromTheTrenches.Commanding.Abstractions;

namespace GSP.Order.Worker.Commands
{
    public class OrderPaidCommand : ICommand
    {
        public long AccountId { get; set; }

        public long OrderId { get; set; }
    }
}