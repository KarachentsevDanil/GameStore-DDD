using GSP.Account.Application.DTOs;
using MediatR;

namespace GSP.Account.WebApi.Commands
{
    public class UpdateAccountCommand : IRequest<GetAccountDto>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}