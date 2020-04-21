using GSP.Rate.Domain.Events;
using GSP.Shared.Utils.Domain.Base;
using System;

namespace GSP.Rate.Domain.Entities
{
    public class RateBase : BaseEntity
    {
        private RateBase(long gameId, long accountId, string comment, int rating)
        {
            GameId = gameId;
            AccountId = accountId;
            Comment = comment;
            Rating = rating;
            CreatedAt = DateTime.UtcNow;
        }

        private RateBase()
        {
        }

        public long GameId { get; private set; }

        public long AccountId { get; private set; }

        public string Comment { get; private set; }

        public int Rating { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Account Account { get; private set; }

        public static RateBase Create(long gameId, long accountId, string comment, int rating)
        {
            var rate = new RateBase(gameId, accountId, comment, rating);

            rate.DomainEvents.Add(new RateCreatedEvent(rate.Id, rate.GameId, rate.Rating, rate.Comment));

            return rate;
        }

        public void Update(string comment, int rating)
        {
            Comment = comment;
            Rating = rating;
            DomainEvents.Add(new RateCreatedEvent(Id, GameId, Rating, Comment));
        }
    }
}