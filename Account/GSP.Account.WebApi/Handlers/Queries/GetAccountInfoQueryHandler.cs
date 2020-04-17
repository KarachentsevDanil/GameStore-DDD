using GSP.Account.Application.DTOs;
using GSP.Account.Application.Services.Contracts;
using GSP.Account.WebApi.Queries;
using GSP.Shared.Utils.WebApi.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Account.WebApi.Handlers.Queries
{
    public class GetAccountInfoQueryHandler : BaseResponseHandler<GetAccountInfoQuery, GetAccountDto>
    {
        private readonly IAccountService _accountService;

        public GetAccountInfoQueryHandler(IAccountService accountService, ILogger<GetAccountInfoQuery> logger)
            : base(logger)
        {
            _accountService = accountService;
        }

        protected override async Task<GetAccountDto> ExecuteAsync(GetAccountInfoQuery request, CancellationToken ct)
        {
            return await _accountService.GetAccountAsync(request.Email, ct);
        }
    }
}