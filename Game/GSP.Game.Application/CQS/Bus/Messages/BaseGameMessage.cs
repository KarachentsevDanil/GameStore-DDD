using System;
using GSP.Game.Application.UseCases.DTOs.Games;
using GSP.Game.Domain.Enums;
using GSP.Shared.Utils.Common.EventBus.Base.Models;

namespace GSP.Game.Application.CQS.Bus.Messages
{
    public abstract class BaseGameMessage : IntegrationEvent
    {
        public long Id { get; set; }

        public long GenreId { get; set; }

        public string Name { get; set; }

        public double AverageRating { get; set; }

        public double OrderCounts { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public AgeRestrictionSystem AgeRestrictionSystem { get; set; }

        public Uri IconUri { get; set; }

        public Uri PhotoUri { get; set; }
    }
}