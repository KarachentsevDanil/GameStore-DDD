using GSP.Shared.Utils.Common.Cache.Base.Contracts;
using GSP.Shared.Utils.Common.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Application.CQS.Handlers.Abstracts
{
    public abstract class BaseCachedResponseHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult>
        where TRequest : IRequest<TResult>
    {
        private readonly ICacheManager _cacheManager;

        private readonly TimeSpan? _customCacheExpirationTime;

        protected BaseCachedResponseHandler(ILogger<TRequest> logger, ICacheManager cacheManager, TimeSpan? customCacheExpirationTime = null)
        {
            Logger = logger;
            _cacheManager = cacheManager;
            _customCacheExpirationTime = customCacheExpirationTime;
        }

        protected ILogger<TRequest> Logger { get; }

        public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogInformation($"Execute handler {nameof(TRequest)} with parameter {request.ToJsonString()}");

                var result = await _cacheManager.GetAsync<TResult>(GetCacheKey(request));

                if (result == null)
                {
                    result = await ExecuteAsync(request, cancellationToken);
                    await _cacheManager.AddAsync(result, GetCacheKey(request), _customCacheExpirationTime);
                }

                return result;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error occured in {nameof(TRequest)} handler", ex);
                throw;
            }
        }

        protected abstract Task<TResult> ExecuteAsync(TRequest request, CancellationToken ct);

        protected abstract string GetCacheKey(TRequest request);
    }
}