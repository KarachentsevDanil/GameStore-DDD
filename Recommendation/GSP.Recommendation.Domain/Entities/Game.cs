using GSP.Shared.Utils.Domain.Base;

namespace GSP.Recommendation.Domain.Entities
{
    public class Game : BaseEntity
    {
        public Game(long id, long genreId)
        {
            Id = id;
            GenreId = genreId;
        }

        public long GenreId { get; private set; }

        public long CountOfOrders { get; private set; }

        public long CountOfReviews { get; private set; }

        public float AverageRating { get; private set; }

        public void UpdateOrderCount(long countOfOrders)
        {
            CountOfOrders = countOfOrders;
        }

        public void UpdateRating(long countOfReviews, float averageRating)
        {
            CountOfReviews = countOfReviews;
            AverageRating = averageRating;
        }
    }
}