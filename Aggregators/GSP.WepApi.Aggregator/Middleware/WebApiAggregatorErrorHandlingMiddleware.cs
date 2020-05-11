using GSP.Shared.Utils.Application.CQS.Models.Validations;
using GSP.Shared.Utils.Application.UseCases.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Refit;
using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace GSP.WepApi.Aggregator.Middleware
{
    public class WebApiAggregatorErrorHandlingMiddleware
    {
        private readonly ILogger<WebApiAggregatorErrorHandlingMiddleware> _logger;

        private readonly RequestDelegate _next;

        public WebApiAggregatorErrorHandlingMiddleware(ILogger<WebApiAggregatorErrorHandlingMiddleware> logger, RequestDelegate next)
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
            catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = MediaTypeNames.Application.Json;

                if (ex.HasContent)
                {
                    var validationError = JsonConvert.DeserializeObject<ValidationError>(ex.Content);
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(validationError));
                }
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