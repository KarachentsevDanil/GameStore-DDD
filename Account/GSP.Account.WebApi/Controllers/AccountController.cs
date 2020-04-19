using GSP.Account.Application.CQS.Commands;
using GSP.Account.Application.CQS.Queries;
using GSP.Account.Application.UseCases.DTOs;
using GSP.Account.Application.UseCases.Exceptions;
using GSP.Shared.Utils.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using static GSP.Shared.Utils.WebApi.Helpers.ActionResultHelper;

namespace GSP.Account.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Login to account
        /// </summary>
        /// <param name="loginCommand"></param>
        /// <returns>
        /// <see cref="TokenDto"/>
        /// </returns>
        /// <response code="400">Fill all required fields</response>
        /// <response code="400">Password is not correct</response>
        /// <response code="404">Account doesn't exist</response>
        [HttpPost("login")]
        [ProducesResponseType(typeof(TokenDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Login([FromBody] LoginToAccountCommand loginCommand)
        {
            try
            {
                var token = await _mediator.Send(loginCommand);
                return Ok(token);
            }
            catch (AccountNotFoundException)
            {
                return NotFound();
            }
            catch (WrongPasswordException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Create new account
        /// </summary>
        /// <param name="createAccountCommand"></param>
        /// <returns>
        /// <see cref="GetAccountDto"/>
        /// </returns>
        /// <response code="400">Fill all required fields</response>
        /// <response code="400">Account already exists</response>
        [HttpPost]
        [ProducesResponseType(typeof(GetAccountDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] CreateAccountCommand createAccountCommand)
        {
            try
            {
                var account = await _mediator.Send(createAccountCommand);
                return CreatedAt(account);
            }
            catch (AccountAlreadyExistException)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update account
        /// </summary>
        /// <param name="updateAccountCommand"></param>
        /// <returns>
        /// <see cref="GetAccountDto"/>
        /// </returns>
        /// <response code="400">Fill all required fields</response>
        /// <response code="404">User does not exist</response>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(typeof(GetAccountDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] UpdateAccountCommand updateAccountCommand)
        {
            try
            {
                updateAccountCommand.Id = User.GetUserId();

                var account = await _mediator.Send(updateAccountCommand);

                return Ok(account);
            }
            catch (AccountNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Get my account info
        /// </summary>
        /// <returns>
        /// <see cref="GetAccountDto"/>
        /// </returns>
        /// <response code="401">User is unauthorized</response>
        /// <response code="404">User does not exist</response>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(GetAccountDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Info()
        {
            try
            {
                var account = await _mediator.Send(new GetAccountInfoQuery(User.GetUserEmail()));
                return Ok(account);
            }
            catch (AccountNotFoundException)
            {
                return NotFound();
            }
        }
    }
}