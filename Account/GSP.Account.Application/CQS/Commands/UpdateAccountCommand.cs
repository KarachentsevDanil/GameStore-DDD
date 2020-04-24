using GSP.Account.Application.UseCases.DTOs;
using MediatR;

namespace GSP.Account.Application.CQS.Commands
{
    public class UpdateAccountCommand : IRequest<GetAccountDto>
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}