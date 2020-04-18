using GSP.Account.Application.CQS.Queries;
using GSP.Account.Application.UseCases.DTOs;
using GSP.Account.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Account.Application.CQS.Handlers.Queries
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