using MediatR;

namespace GSP.Recommendation.Application.CQS.Commands.Games
{
    public class CreateGameCommand : IRequest
    {
        public CreateGameCommand(long id, long genreId)
        {
            Id = id;
            GenreId = genreId;
        }

        public long Id { get; set; }

        public long GenreId { get; set; }
    }
}