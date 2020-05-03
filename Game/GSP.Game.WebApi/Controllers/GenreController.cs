using GSP.Game.Application.CQS.Commands.Genres;
using GSP.Game.Application.CQS.Queries.Genres;
using GSP.Game.Application.UseCases.DTOs.Genres;
using GSP.Shared.Utils.Domain.Account.Enums;
using GSP.Shared.Utils.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace GSP.Game.WebApi.Controllers
{
    [Authorize(Roles = nameof(UserRoleType.Admin))]
    public class GenreController
        : BaseCrudController<GetGenreDto, CreateGenreCommand, UpdateGenreCommand, GetGenreByIdQuery, GetGenrePagedListQuery>
    {
        public GenreController(IMediator mediator)
            : base(mediator)
        {
        }
    }
}