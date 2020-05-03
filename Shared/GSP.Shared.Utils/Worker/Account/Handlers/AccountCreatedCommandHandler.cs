using AzureFromTheTrenches.Commanding.Abstractions;
using GSP.Shared.Utils.Application.Account.UseCases.DTOs;
using GSP.Shared.Utils.Application.Account.UseCases.Services.Contracts;
using GSP.Shared.Utils.Common.Extensions;
using GSP.Shared.Utils.Worker.Account.Commands;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Worker.Account.Handlers
{
    public class AccountCreatedCommandHandler : ICommandHandler<AccountCreatedCommand>
    {
        private readonly IAccountService _accountService;

        private readonly ILogger _logger;

        public AccountCreatedCommandHandler(ILogger<AccountCreatedCommandHandler> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        public async Task ExecuteAsync(AccountCreatedCommand command)
        {
            _logger.LogInformation(
                $"{nameof(AccountCreatedCommand)} has been triggered with parameter {command.ToJsonString()}");

            AddAccountDto accountDto =
                new AddAccountDto(command.Id, command.FirstName, command.LastName, command.Email);

            await _accountService.AddAsync(accountDto);
        }
    }
}