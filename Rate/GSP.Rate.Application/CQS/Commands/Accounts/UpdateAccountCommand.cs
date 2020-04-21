using GSP.Rate.Application.UseCases.DTOs.Accounts;
using GSP.Shared.Utils.Application.CQS.Commands;

namespace GSP.Rate.Application.CQS.Commands.Accounts
{
    public class UpdateAccountCommand : BaseUpdateItemCommand<GetAccountDto>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}