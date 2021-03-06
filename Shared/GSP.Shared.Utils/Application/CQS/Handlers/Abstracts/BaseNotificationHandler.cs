﻿using GSP.Shared.Utils.Common.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Application.CQS.Handlers.Abstracts
{
    public abstract class BaseNotificationHandler<TRequest> : INotificationHandler<TRequest>
        where TRequest : INotification
    {
        protected BaseNotificationHandler(ILogger<TRequest> logger)
        {
            Logger = logger;
        }

        protected ILogger<TRequest> Logger { get; }

        public async Task Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogInformation($"Execute handler {typeof(TRequest).Name} with parameter {request.ToJsonString()}");

                await ExecuteAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                Logger.LogInformation($"Error occured in {typeof(TRequest).Name} handler", ex);
                throw;
            }
        }

        protected abstract Task ExecuteAsync(TRequest request, CancellationToken ct);
    }
}