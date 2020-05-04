using MediatR;

namespace GSP.Recommendation.Application.CQS.Commands.Games
{
    public class UpdateGameOrderCountCommand : IRequest
    {
        public UpdateGameOrderCountCommand(long id, int orderCount)
        {
            Id = id;
            OrderCount = orderCount;
        }

        public long Id { get; set; }

        public int OrderCount { get; set; }
    }
}