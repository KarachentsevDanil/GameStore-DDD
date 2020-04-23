using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Order.Application.UseCases.DTOs.Orders
{
    public class AddOrderDto : BaseAddItemDto
    {
        public long AccountId { get; set; }
    }
}