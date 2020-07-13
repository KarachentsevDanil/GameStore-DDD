using GSP.Shared.Utils.Domain.Account.Enums;
using GSP.Shared.Utils.WebApi.Controllers;
using GSP.$projectPlainName$.Application.CQS.Commands.$domainName$s;
using GSP.$projectPlainName$.Application.CQS.Queries.$domainName$s;
using GSP.$projectPlainName$.Application.UseCases.DTOs.$domainName$s;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace $safeprojectname$.Controllers
{
    [Authorize(Roles = nameof(UserRoleType.Admin))]
    public class $domainName$Controller
        : BaseCrudController<
            Get$domainName$Dto,
            Add$domainName$Command,
            Update$domainName$Command,
            Get$domainName$ByIdQuery,
            Get$domainName$PagedQuery>
    {
        public $domainName$Controller(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Get $domainNameLowerTitleCase$s by query
        /// </summary>
        /// <param name="query">
        /// <see cref="Get$domainName$GridQuery"/>
        /// </param>
        /// <returns>
        /// <see cref="Get$domainName$Dto"/>
        /// </returns>
        [HttpPost("grid")]
        [ProducesResponseType(typeof(Get$domainName$Dto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get$domainName$sGrid([FromBody] Get$domainName$GridQuery query)
        {
            var games = await Mediator.Send(query);
            return Ok(games);
        }
    }
}