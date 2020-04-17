using GSP.Account.Application.DTOs;
using MediatR;

namespace GSP.Account.WebApi.Commands
{
    public class LoginToAccountCommand : IRequest<TokenDto>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}