using GSP.Order.Application.UseCases.DTOs.Orders;
using MediatR;

namespace GSP.Order.Application.CQS.Commands.Orders
{
    public class AddOrderToGameCommand : IRequest<GetOrderDto>
    {
        public long AccountId { get; set; }

        public long GameId { get; set; }
    }
}