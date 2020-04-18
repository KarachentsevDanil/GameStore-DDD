using GSP.Account.Application.UseCases.DTOs;
using MediatR;

namespace GSP.Account.Application.CQS.Queries
{
    public class GetAccountInfoQuery : IRequest<GetAccountDto>
    {
        public GetAccountInfoQuery(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }
}