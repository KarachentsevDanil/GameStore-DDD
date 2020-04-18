using GSP.Account.Application.UseCases.DTOs;
using MediatR;

namespace GSP.Account.Application.CQS.Commands
{
    public class CreateAccountCommand : IRequest<GetAccountDto>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}