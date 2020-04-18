using GSP.Account.Application.UseCases.DTOs;
using MediatR;

namespace GSP.Account.Application.CQS.Commands
{
    public class LoginToAccountCommand : IRequest<TokenDto>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}