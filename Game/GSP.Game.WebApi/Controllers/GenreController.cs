using GSP.Game.Application.CQS.Commands.Genres;
using GSP.Game.Application.CQS.Queries.Genres;
using GSP.Game.Application.UseCases.DTOs.Genres;
using GSP.Shared.Utils.WebApi.Controllers;
using MediatR;

namespace GSP.Game.WebApi.Controllers
{
    public class GenreController
        : BaseCrudController<GetGenreDto, CreateGenreCommand, UpdateGenreCommand, GetGenreByIdQuery, GetGenrePagedListQuery>
    {
        public GenreController(IMediator mediator)
            : base(mediator)
        {
        }
    }
}