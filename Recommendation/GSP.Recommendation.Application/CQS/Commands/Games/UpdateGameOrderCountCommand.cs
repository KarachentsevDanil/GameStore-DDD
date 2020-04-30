using MediatR;

namespace GSP.Recommendation.Application.CQS.Commands.Games
{
    public class UpdateGameOrderCountCommand : IRequest
    {
        public long Id { get; set; }

        public int OrderCount { get; set; }
    }
}