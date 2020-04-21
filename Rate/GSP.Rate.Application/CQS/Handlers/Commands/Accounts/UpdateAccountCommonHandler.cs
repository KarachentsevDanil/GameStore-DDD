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
    public class UpdateAccountCommonHandler : BaseValidationResponseHandler<UpdateAccountCommand, GetAccountDto>
    {
        private readonly IMapper _mapper;

        private readonly IAccountService _accountService;

        public UpdateAccountCommonHandler(
            IValidator<UpdateAccountCommand> validator,
            ILogger<UpdateAccountCommand> logger,
            IMapper mapper,
            IAccountService accountService)
            : base(validator, logger)
        {
            _mapper = mapper;
            _accountService = accountService;
        }

        protected override async Task<GetAccountDto> ExecuteAsync(UpdateAccountCommand request, CancellationToken ct)
        {
            UpdateAccountDto accountDto = _mapper.Map<UpdateAccountDto>(request);
            return await _accountService.UpdateAsync(accountDto, ct);
        }
    }
}