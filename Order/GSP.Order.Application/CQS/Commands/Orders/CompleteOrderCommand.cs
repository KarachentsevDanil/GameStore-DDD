using GSP.Order.Application.UseCases.DTOs.Orders;
using MediatR;

namespace GSP.Order.Application.CQS.Commands.Orders
{
    public class CompleteOrderCommand : IRequest<GetOrderDto>
    {
        public CompleteOrderCommand(long accountId)
        {
            AccountId = accountId;
        }

        public long AccountId { get; set; }
    }
}