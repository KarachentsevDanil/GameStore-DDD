using GSP.Game.Application.CQS.Commands.Publishers;
using GSP.Game.Application.CQS.Queries.Publishers;
using GSP.Game.Application.UseCases.DTOs.Publishers;
using GSP.Shared.Utils.Domain.Account.Enums;
using GSP.Shared.Utils.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace GSP.Game.WebApi.Controllers
{
    [Authorize(Roles = nameof(UserRoleType.Admin))]
    public class PublisherController
        : BaseCrudController<GetPublisherDto, CreatePublisherCommand, UpdatePublisherCommand, GetPublisherByIdQuery, GetPublisherPagedListQuery>
    {
        public PublisherController(IMediator mediator)
            : base(mediator)
        {
        }
    }
}