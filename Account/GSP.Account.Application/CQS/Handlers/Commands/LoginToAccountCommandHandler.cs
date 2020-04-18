using AutoMapper;
using FluentValidation;
using GSP.Account.Application.CQS.Commands;
using GSP.Account.Application.UseCases.DTOs;
using GSP.Account.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Account.Application.CQS.Handlers.Commands
{
    public class LoginToAccountCommandHandler : BaseValidationResponseHandler<LoginToAccountCommand, TokenDto>
    {
        private readonly IMapper _mapper;

        private readonly IAccountService _accountService;

        public LoginToAccountCommandHandler(
            IMapper mapper,
            IAccountService accountService,
            AbstractValidator<LoginToAccountCommand> validator,
            ILogger<LoginToAccountCommand> logger)
            : base(validator, logger)
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