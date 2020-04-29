using System;
using System.Collections.Generic;

namespace GSP.Recommendation.Application.UseCases.DTOs.Orders
{
    public class AddOrderDto
    {
        public long Id { get; set; }

        public long AccountId { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<OrderGameDto> Games { get; set; }
    }
}