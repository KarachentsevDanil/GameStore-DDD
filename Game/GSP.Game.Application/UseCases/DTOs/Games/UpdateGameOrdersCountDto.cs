using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Game.Application.UseCases.DTOs.Games
{
    public class UpdateGameOrdersCountDto : BaseUpdateItemDto
    {
        public int OrdersCount { get; set; }
    }
}