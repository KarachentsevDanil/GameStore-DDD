using AutoMapper;
using FluentValidation;
using GSP.Rate.Application.CQS.Commands.Accounts;
using GSP.Rate.Application.UseCases.DTOs.Accounts;
using GSP.Rate.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Rate.Application.CQS.Handlers.Commands.Accounts
{
    public class CreateAccountCommonHandler : BaseValidationResponseHandler<CreateAccountCommand, GetAccountDto>
    {
        private readonly IMapper _mapper;

        private readonly IAccountService _accountService;

        public CreateAccountCommonHandler(
            IValidator<CreateAccountCommand> validator,
            ILogger<CreateAccountCommand> logger,
            IMapper mapper,
            IAccountService accountService)
            : base(validator, logger)
        {
            _mapper = mapper;
            _accountService = accountService;
        }

        protected override async Task<GetAccountDto> ExecuteAsync(CreateAccountCommand request, CancellationToken ct)
        {
            AddAccountDto accountDto = _mapper.Map<AddAccountDto>(request);
            return await _accountService.AddAsync(accountDto, ct);
        }
    }
}