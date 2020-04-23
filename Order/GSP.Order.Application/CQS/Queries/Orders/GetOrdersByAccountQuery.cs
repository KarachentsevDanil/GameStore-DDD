using GSP.Order.Application.UseCases.DTOs.Orders;
using MediatR;
using System.Collections.Immutable;

namespace GSP.Order.Application.CQS.Queries.Orders
{
    public class GetOrdersByAccountQuery : IRequest<IImmutableList<GetOrderDto>>
    {
        public long AccountId { get; set; }
    }
}