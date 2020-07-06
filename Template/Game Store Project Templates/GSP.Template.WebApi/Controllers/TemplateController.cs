using GSP.Shared.Utils.Domain.Account.Enums;
using GSP.Shared.Utils.WebApi.Controllers;
using GSP.Template.Application.CQS.Commands.Templates;
using GSP.Template.Application.CQS.Queries.Templates;
using GSP.Template.Application.UseCases.DTOs.Templates;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace GSP.Template.WebApi.Controllers
{
    [Authorize(Roles = nameof(UserRoleType.Admin))]
    public class TemplateController
        : BaseCrudController<
            GetTemplateDto,
            AddTemplateCommand,
            UpdateTemplateCommand,
            GetTemplateByIdQuery,
            GetTemplatePagedQuery>
    {
        public TemplateController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Get templates by query
        /// </summary>
        /// <param name="query">
        /// <see cref="GetTemplateGridQuery"/>
        /// </param>
        /// <returns>
        /// <see cref="GetTemplateDto"/>
        /// </returns>
        [HttpPost("grid")]
        [ProducesResponseType(typeof(GetTemplateDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTemplatesGrid([FromBody] GetTemplateGridQuery query)
        {
            var games = await Mediator.Send(query);
            return Ok(games);
        }
    }
}