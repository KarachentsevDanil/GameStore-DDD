using GSP.Recommendation.Application.UseCases.DTOs.Orders;
using MediatR;
using System;
using System.Collections.Generic;

namespace GSP.Recommendation.Application.CQS.Commands.Orders
{
    public class CreateOrderCommand : IRequest
    {
        public long Id { get; set; }

        public long AccountId { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<OrderGameDto> Games { get; set; }
    }
}