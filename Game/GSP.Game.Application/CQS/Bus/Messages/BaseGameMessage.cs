using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Shared.Utils.Common.ServiceBus.Base.Models;

namespace GSP.Game.Application.CQS.Bus.Messages
{
    public abstract class BaseGameMessage : IntegrationEvent
    {
        public long Id { get; set; }

        public GameDetailsDto GameDetails { get; set; }
    }
}