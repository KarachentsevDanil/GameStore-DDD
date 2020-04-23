using GSP.Order.Application.UseCases.DTOs.Orders;
using MediatR;
using System.Collections.Immutable;

namespace GSP.Order.Application.CQS.Queries.Orders
{
    public class GetOrdersByAccountQuery : IRequest<IImmutableList<GetOrderDto>>
    {
        public GetOrdersByAccountQuery(long accountId)
        {
            AccountId = accountId;
        }

        public long AccountId { get; set; }
    }
}