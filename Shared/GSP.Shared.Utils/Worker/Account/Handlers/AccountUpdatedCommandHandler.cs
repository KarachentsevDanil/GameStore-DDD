using AzureFromTheTrenches.Commanding.Abstractions;
using GSP.Shared.Utils.Application.Account.UseCases.DTOs;
using GSP.Shared.Utils.Application.Account.UseCases.Services.Contracts;
using GSP.Shared.Utils.Common.Extensions;
using GSP.Shared.Utils.Worker.Account.Commands;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Worker.Account.Handlers
{
    public class AccountUpdatedCommandHandler : ICommandHandler<AccountUpdatedCommand>
    {
        private readonly IAccountService _accountService;

        private readonly ILogger _logger;

        public AccountUpdatedCommandHandler(ILogger<AccountUpdatedCommandHandler> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        public async Task ExecuteAsync(AccountUpdatedCommand command)
        {
            _logger.LogInformation(
                $"{nameof(AccountUpdatedCommand)} has been triggered with parameter {command.ToJsonString()}");

            UpdateAccountDto accountDto = new UpdateAccountDto(command.Id, command.FirstName, command.LastName, command.Email);

            await _accountService.UpdateAsync(accountDto);
        }
    }
}