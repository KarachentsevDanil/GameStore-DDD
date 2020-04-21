using MediatR;

namespace GSP.Rate.Domain.Events
{
    public class RateUpdatedEvent : INotification
    {
        public RateUpdatedEvent(long id, long gameId, int rating, string comment)
        {
            Id = id;
            GameId = gameId;
            Rating = rating;
            Comment = comment;
        }

        public long Id { get; set; }

        public long GameId { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }
    }
}