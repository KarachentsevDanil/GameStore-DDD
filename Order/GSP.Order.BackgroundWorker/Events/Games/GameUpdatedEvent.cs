using GSP.Shared.Utils.Common.ServiceBus.Base.Models;
using System;

namespace GSP.Order.BackgroundWorker.Events.Games
{
    public class GameUpdatedEvent : IntegrationEvent
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public Uri PhotoUri { get; set; }

        public Uri IconUri { get; set; }
    }
}