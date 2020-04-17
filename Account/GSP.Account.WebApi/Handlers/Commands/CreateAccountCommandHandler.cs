using AutoMapper;
using GSP.Account.Application.DTOs;
using GSP.Account.Application.Services.Contracts;
using GSP.Account.WebApi.Bus;
using GSP.Account.WebApi.Bus.Messages;
using GSP.Account.WebApi.Commands;
using GSP.Shared.Utils.Common.ServiceBus.Contracts;
using GSP.Shared.Utils.WebApi.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Account.WebApi.Handlers.Commands
{
    public class CreateAccountCommandHandler : BaseResponseHandler<CreateAccountCommand, GetAccountDto>
    {
        private readonly IMapper _mapper;

        private readonly IAccountService _accountService;

        private readonly IServiceBusClient _serviceBusClient;

        public CreateAccountCommandHandler(
            IMapper mapper,
            IAccountService accountService,
            ILogger<CreateAccountCommand> logger,
            IServiceBusClient serviceBusClient)
            : base(logger)
        {
            _mapper = mapper;
            _accountService = accountService;
            _serviceBusClient = serviceBusClient;
        }

        protected override async Task<GetAccountDto> ExecuteAsync(CreateAccountCommand request, CancellationToken ct)
        {
            CreateAccountDto createAccountDto = _mapper.Map<CreateAccountDto>(request);

            GetAccountDto accountDto = await _accountService.CreateAccountAsync(createAccountDto, ct);

            AccountCreatedMessage accountCreatedMessage = _mapper.Map<AccountCreatedMessage>(accountDto);

            await _serviceBusClient.PublishAccountCreatedAsync(accountCreatedMessage);

            return accountDto;
        }
    }
}