using GSP.Shared.Grid.Exceptions;
using GSP.Shared.Utils.Application.CQS.Exceptions;
using GSP.Shared.Utils.Application.CQS.Models.Validations;
using GSP.Shared.Utils.Application.UseCases.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.WebApi.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationHandlerException ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = MediaTypeNames.Application.Json;

                await context.Response.WriteAsync(JsonConvert.SerializeObject(ex.ValidationErrors));
            }
            catch (AccessToItemForbiddenException)
            {
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
            }
            catch (ItemNotFoundException)
            {
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
            catch (BusinessLogicException ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = MediaTypeNames.Application.Json;

                var validationError = new ValidationError
                {
                    ErrorCode = ex.ErrorCode,
                    Message = ex.ErrorMessage
                };

                await context.Response.WriteAsync(JsonConvert.SerializeObject(validationError));
            }
            catch (GridFilterException ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = MediaTypeNames.Application.Json;

                var validationError = new ValidationError
                {
                    ErrorCode = nameof(GridFilterException),
                    Message = ex.Message
                };

                await context.Response.WriteAsync(JsonConvert.SerializeObject(validationError));
            }
            catch (Exception exp)
            {
                _logger.LogError($"Global Exception Handler - {exp}");

                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = MediaTypeNames.Application.Json;

                await context.Response.WriteAsync(JsonConvert.SerializeObject(exp));
            }
        }
    }
}