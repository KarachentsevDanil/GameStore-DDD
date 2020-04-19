using GSP.Game.Application.UseCases.DTOs.Genres;
using MediatR;

namespace GSP.Game.Application.CQS.Queries.Genres
{
    public class GetGenreByNameQuery : IRequest<GetGenreDto>
    {
        public string Name { get; set; }
    }
}