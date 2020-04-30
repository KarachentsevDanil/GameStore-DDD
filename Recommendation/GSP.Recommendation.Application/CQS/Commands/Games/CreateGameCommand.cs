using MediatR;

namespace GSP.Recommendation.Application.CQS.Commands.Games
{
    public class CreateGameCommand : IRequest
    {
        public long Id { get; set; }

        public long GenreId { get; set; }
    }
}