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
    public class AccountUpdatedCommandHandler : ICommandHandler<AccountUpdatedCommand>
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public AccountUpdatedCommandHandler(IMediator mediator, IMapper mapper, ILogger logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task ExecuteAsync(AccountUpdatedCommand command)
        {
            _logger.LogInformation(
                $"{nameof(AccountUpdatedCommand)} has been triggered with parameter {command.ToJsonString()}");

            UpdateAccountCommand createAccount = _mapper.Map<UpdateAccountCommand>(command);

            await _mediator.Send(createAccount);
        }
    }
}