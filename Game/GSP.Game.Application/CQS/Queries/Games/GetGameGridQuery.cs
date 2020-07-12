using GSP.Game.Domain.Grids;
using GSP.Shared.Utils.Data.Grid.Models;
using MediatR;

namespace GSP.Game.Application.CQS.Queries.Games
{
    public class GetGameGridQuery : IRequest<GridModel>
    {
        public GameGrid GameBaseGrid { get; set; }
    }
}