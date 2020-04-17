using AutoMapper;
using GSP.Account.Application.DTOs;
using GSP.Account.Application.Services.Contracts;
using GSP.Account.WebApi.Commands;
using GSP.Shared.Utils.WebApi.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Account.WebApi.Handlers.Commands
{
    public class LoginToAccountCommandHandler : BaseResponseHandler<LoginToAccountCommand, TokenDto>
    {
        private readonly IMapper _mapper;

        private readonly IAccountService _accountService;

        public LoginToAccountCommandHandler(IMapper mapper, IAccountService accountService, ILogger<LoginToAccountCommand> logger)
            : base(logger)
        {
            _mapper = mapper;
            _accountService = accountService;
        }

        protected override async Task<TokenDto> ExecuteAsync(LoginToAccountCommand request, CancellationToken ct)
        {
            LoginAccountDto loginAccountDto = _mapper.Map<LoginAccountDto>(request);

            return await _accountService.LoginAsync(loginAccountDto, ct);
        }
    }
}