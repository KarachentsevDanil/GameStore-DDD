﻿using GSP.Shared.Utils.Application.CQS.Exceptions;
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
                await context.Response.WriteAsync(JsonConvert.SerializeObject(ex.ValidationErrors));
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