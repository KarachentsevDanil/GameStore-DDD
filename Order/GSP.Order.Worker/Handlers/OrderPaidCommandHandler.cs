using AutoMapper;
using AzureFromTheTrenches.Commanding.Abstractions;
using GSP.Order.Application.CQS.Commands.Orders;
using GSP.Order.Worker.Commands;
using GSP.Shared.Utils.Common.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GSP.Order.Worker.Handlers
{
    public class OrderPaidCommandHandler : ICommandHandler<OrderPaidCommand>
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public OrderPaidCommandHandler(IMediator mediator, IMapper mapper, ILogger logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task ExecuteAsync(OrderPaidCommand command)
        {
            _logger.LogInformation(
                $"{nameof(OrderPaidCommand)} has been triggered with parameter {command.ToJsonString()}");

            await _mediator.Send(new CompleteOrderCommand(command.AccountId));
        }
    }
}