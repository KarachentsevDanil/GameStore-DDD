using GSP.Game.Application.CQS.Commands.DeveloperStudios;
using GSP.Game.Application.CQS.Queries.DeveloperStudios;
using GSP.Game.Application.UseCases.DTOs.DeveloperStudios;
using GSP.Shared.Utils.Domain.Account.Enums;
using GSP.Shared.Utils.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace GSP.Game.WebApi.Controllers
{
    [Authorize(Roles = nameof(UserRoleType.Admin))]
    public class DeveloperStudioController
        : BaseCrudController<
            GetDeveloperStudioDto,
            CreateDeveloperStudioCommand,
            UpdateDeveloperStudioCommand,
            GetDeveloperStudioByIdQuery,
            GetDeveloperStudioPagedListQuery>
    {
        public DeveloperStudioController(IMediator mediator)
            : base(mediator)
        {
        }
    }
}