using GSP.Shared.Utils.Common.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.WebApi.Handlers.Abstracts
{
    public abstract class BaseVoidHandler<TRequest> : AsyncRequestHandler<TRequest>
        where TRequest : IRequest
    {
        protected BaseVoidHandler(ILogger<TRequest> logger)
        {
            Logger = logger;
        }

        protected ILogger<TRequest> Logger { get; }

        protected override async Task Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogInformation($"Execute handler {nameof(TRequest)} with parameter {request.ToJsonString()}");

                await ExecuteAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                Logger.LogInformation($"Error occured in {nameof(TRequest)} handler", ex);
                throw;
            }
        }

        protected abstract Task ExecuteAsync(TRequest request, CancellationToken ct);
    }
}