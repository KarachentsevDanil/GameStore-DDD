using GSP.Shared.Utils.Application.Account.UseCases.DTOs;
using GSP.Shared.Utils.Application.CQS.Commands;

namespace GSP.Shared.Utils.Application.Account.CQS.Commands
{
    public class UpdateAccountCommand : BaseUpdateItemCommand<GetAccountDto>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}