using GSP.Game.Application.CQS.Commands.DeveloperStudios;
using GSP.Game.Application.CQS.Queries.DeveloperStudios;
using GSP.Game.Application.UseCases.DTOs.DeveloperStudios;
using GSP.Shared.Utils.WebApi.Controllers;
using MediatR;

namespace GSP.Game.WebApi.Controllers
{
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
