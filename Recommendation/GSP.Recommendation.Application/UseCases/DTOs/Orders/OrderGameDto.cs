namespace GSP.Recommendation.Application.UseCases.DTOs.Orders
{
    public class OrderGameDto
    {
        public OrderGameDto(long orderId, long gameId)
        {
            OrderId = orderId;
            GameId = gameId;
        }

        public OrderGameDto()
        {
        }

        public long OrderId { get; set; }

        public long GameId { get; set; }
    }
}