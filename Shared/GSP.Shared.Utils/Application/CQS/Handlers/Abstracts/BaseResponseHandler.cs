using GSP.Shared.Utils.Common.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Application.CQS.Handlers.Abstracts
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
                Logger.LogInformation($"Execute handler {typeof(TRequest).Name} with parameter {request.ToJsonString()}");

                await PreExecuteAsync(request, cancellationToken);

                var result = await ExecuteAsync(request, cancellationToken);

                await PostExecuteAsync(result, cancellationToken);

                return result;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error occured in {typeof(TRequest).Name} handler", ex);
                throw;
            }
        }

        protected abstract Task<TResult> ExecuteAsync(TRequest request, CancellationToken ct);

        protected virtual Task PreExecuteAsync(TRequest request, CancellationToken ct)
        {
            return Task.CompletedTask;
        }

        protected virtual Task PostExecuteAsync(TResult result, CancellationToken ct)
        {
            return Task.CompletedTask;
        }
    }
}