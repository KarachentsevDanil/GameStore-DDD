using AutoMapper;
using AzureFromTheTrenches.Commanding.Abstractions;
using GSP.Rate.Application.CQS.Commands.Accounts;
using GSP.Rate.Worker.Commands;
using GSP.Shared.Utils.Common.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GSP.Rate.Worker.Handlers
{
    public class AccountCreatedCommandHandler : ICommandHandler<AccountCreatedCommand>
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public AccountCreatedCommandHandler(IMediator mediator, IMapper mapper, ILogger logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task ExecuteAsync(AccountCreatedCommand command)
        {
            _logger.LogInformation(
                $"{nameof(AccountCreatedCommand)} has been triggered with parameter {command.ToJsonString()}");

            CreateAccountCommand createAccount = _mapper.Map<CreateAccountCommand>(command);

            await _mediator.Send(createAccount);
        }
    }
}