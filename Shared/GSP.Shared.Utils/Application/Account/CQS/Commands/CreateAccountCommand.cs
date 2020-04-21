using GSP.Shared.Utils.Application.Account.UseCases.DTOs;
using GSP.Shared.Utils.Application.CQS.Commands;

namespace GSP.Shared.Utils.Application.Account.CQS.Commands
{
    public class CreateAccountCommand : BaseCreateItemCommand<GetAccountDto>
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}