using AutoMapper;
using FluentValidation;
using GSP.Account.Application.CQS.Bus;
using GSP.Account.Application.CQS.Bus.Messages;
using GSP.Account.Application.CQS.Commands;
using GSP.Account.Application.UseCases.DTOs;
using GSP.Account.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Account.Application.CQS.Handlers.Commands
{
    public class CreateAccountCommandHandler : BaseValidationResponseHandler<CreateAccountCommand, GetAccountDto>
    {
        private readonly IMapper _mapper;

        private readonly IAccountService _accountService;

        private readonly IServiceBusClient _serviceBusClient;

        public CreateAccountCommandHandler(
            IMapper mapper,
            IAccountService accountService,
            IValidator<CreateAccountCommand> validator,
            ILogger<CreateAccountCommand> logger,
            IServiceBusClient serviceBusClient)
            : base(validator, logger)
        {
            _mapper = mapper;
            _accountService = accountService;
            _serviceBusClient = serviceBusClient;
        }

        protected override async Task<GetAccountDto> ExecuteAsync(CreateAccountCommand request, CancellationToken ct)
        {
            CreateAccountDto createAccountDto = _mapper.Map<CreateAccountDto>(request);

            GetAccountDto accountDto = await _accountService.AddAsync(createAccountDto, ct);

            AccountCreatedMessage accountCreatedMessage = _mapper.Map<AccountCreatedMessage>(accountDto);

            await _serviceBusClient.PublishAccountCreatedAsync(accountCreatedMessage);

            return accountDto;
        }
    }
}