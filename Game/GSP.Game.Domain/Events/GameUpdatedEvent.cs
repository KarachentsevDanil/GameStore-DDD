using GSP.Game.Domain.Enums;
using MediatR;
using System;

namespace GSP.Game.Domain.Events
{
    public class GameUpdatedEvent : INotification
    {
        public long Id { get; set; }

        public long GenreId { get; set; }

        public string Name { get; set; }

        public double AverageRating { get; set; }

        public int ReviewCount { get; set; }

        public int OrderCount { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public AgeRestrictionSystem AgeRestrictionSystem { get; set; }

        public Uri IconUri { get; set; }

        public Uri PhotoUri { get; set; }
    }
}