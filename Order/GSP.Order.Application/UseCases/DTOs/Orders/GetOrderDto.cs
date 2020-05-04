using GSP.Order.Application.UseCases.DTOs.Games;
using GSP.Order.Domain.Enums;
using GSP.Shared.Utils.Application.UseCases.DTOs;
using System.Collections.Generic;

namespace GSP.Order.Application.UseCases.DTOs.Orders
{
    public class GetOrderDto : BaseGetItemDto
    {
        public OrderStatus Status { get; set; }

        public ICollection<GetGameDto> Games { get; set; }
    }
}