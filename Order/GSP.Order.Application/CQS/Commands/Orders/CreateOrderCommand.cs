using GSP.Order.Application.UseCases.DTOs.Orders;
using GSP.Shared.Utils.Application.CQS.Commands;

namespace GSP.Order.Application.CQS.Commands.Orders
{
    public class CreateOrderCommand : BaseCreateItemCommand<GetOrderDto>
    {
        public long AccountId { get; set; }
    }
}