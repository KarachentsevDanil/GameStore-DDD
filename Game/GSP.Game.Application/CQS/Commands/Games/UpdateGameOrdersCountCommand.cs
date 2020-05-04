using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Shared.Utils.Application.CQS.Commands;

namespace GSP.Game.Application.CQS.Commands.Games
{
    public class UpdateGameOrdersCountCommand : BaseUpdateItemCommand<GetGameDto>
    {
        public UpdateGameOrdersCountCommand(long id, int ordersCount)
        {
            Id = id;
            OrdersCount = ordersCount;
        }

        public int OrdersCount { get; set; }
    }
}