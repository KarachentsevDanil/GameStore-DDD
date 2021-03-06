﻿using GSP.Order.Application.UseCases.DTOs.Orders;
using MediatR;

namespace GSP.Order.Application.CQS.Queries.Orders
{
    public class GetOrderByAccountQuery : IRequest<GetOrderDto>
    {
        public GetOrderByAccountQuery(long accountId)
        {
            AccountId = accountId;
        }

        public long AccountId { get; set; }
    }
}