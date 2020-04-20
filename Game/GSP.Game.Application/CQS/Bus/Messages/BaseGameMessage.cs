using GSP.Game.Application.UseCases.DTOs.Games;

namespace GSP.Game.Application.CQS.Bus.Messages
{
    public abstract class BaseGameMessage
    {
        public long Id { get; set; }

        public GameDetailsDto GameDetails { get; set; }
    }
}