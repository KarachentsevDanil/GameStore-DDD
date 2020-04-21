using GSP.Rate.Application.UseCases.DTOs.Accounts;
using GSP.Shared.Utils.Application.CQS.Commands;

namespace GSP.Rate.Application.CQS.Commands.Accounts
{
    public class CreateAccountCommand : BaseCreateItemCommand<GetAccountDto>
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}