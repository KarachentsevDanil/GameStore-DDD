using AzureFromTheTrenches.Commanding.Abstractions;

namespace GSP.Rate.Worker.Commands
{
    public class AccountUpdatedCommand : ICommand
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}