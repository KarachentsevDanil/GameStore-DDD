using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Game.Application.UseCases.DTOs.Games
{
    public class UpdateGameOrdersCountDto : BaseUpdateItemDto
    {
        public UpdateGameOrdersCountDto(long id, int ordersCount)
        {
            Id = id;
            OrdersCount = ordersCount;
        }

        public int OrdersCount { get; set; }
    }
}