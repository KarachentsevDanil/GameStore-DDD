using GSP.Account.Application.DTOs;
using MediatR;

namespace GSP.Account.WebApi.Queries
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