using GSP.Shared.Utils.Common.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.WebApi.Handlers.Abstracts
{
    public abstract class BaseResponseHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult>
        where TRequest : IRequest<TResult>
    {
        protected BaseResponseHandler(ILogger<TRequest> logger)
        {
            Logger = logger;
        }

        protected ILogger<TRequest> Logger { get; }

        public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogInformation($"Execute handler {nameof(TRequest)} with parameter {request.ToJsonString()}");
                return await ExecuteAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error occured in {nameof(TRequest)} handler", ex);
                throw;
            }
        }

        protected abstract Task<TResult> ExecuteAsync(TRequest request, CancellationToken ct);
    }
}