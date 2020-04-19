using GSP.Game.Application.CQS.Commands.Publishers;
using GSP.Game.Application.CQS.Queries.Publishers;
using GSP.Game.Application.UseCases.DTOs.Publishers;
using GSP.Shared.Utils.WebApi.Controllers;
using MediatR;

namespace GSP.Game.WebApi.Controllers
{
    public class PublisherController
        : BaseCrudController<GetPublisherDto, CreatePublisherCommand, UpdatePublisherCommand, GetPublisherByIdQuery, GetPublisherPagedListQuery>
    {
        public PublisherController(IMediator mediator)
            : base(mediator)
        {
        }
    }
}
