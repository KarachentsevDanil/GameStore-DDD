using AutoMapper;
using GSP.Recommendation.Application.CQS.Commands.Orders;
using GSP.Recommendation.Application.UseCases.DTOs.Orders;
using GSP.Recommendation.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Recommendation.Application.CQS.Handlers.Commands.Orders
{
    public class CreateOrderCommandHandler : BaseVoidHandler<CreateOrderCommand>
    {
        private readonly IMapper _mapper;

        private readonly IOrderService _orderService;

        public CreateOrderCommandHandler(ILogger<CreateOrderCommand> logger, IMapper mapper, IOrderService orderService)
            : base(logger)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        protected override async Task ExecuteAsync(CreateOrderCommand request, CancellationToken ct)
        {
            AddOrderDto order = _mapper.Map<AddOrderDto>(request);
            await _orderService.AddAsync(order, ct);
        }
    }
}