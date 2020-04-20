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
    public class UpdateAccountCommandHandler : BaseValidationResponseHandler<UpdateAccountCommand, GetAccountDto>
    {
        private readonly IMapper _mapper;

        private readonly IAccountService _accountService;

        public UpdateAccountCommandHandler(
            IMapper mapper,
            IAccountService accountService,
            IValidator<UpdateAccountCommand> validator,
            ILogger<UpdateAccountCommand> logger)
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