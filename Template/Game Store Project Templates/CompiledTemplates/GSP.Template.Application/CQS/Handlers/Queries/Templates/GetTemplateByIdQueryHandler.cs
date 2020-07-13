using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using $safeprojectname$.CQS.Queries.$domainName$s;
using $safeprojectname$.UseCases.DTOs.$domainName$s;
using $safeprojectname$.UseCases.Services.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.CQS.Handlers.Queries.$domainName$s
{
    public class Get$domainName$ByIdQueryHandler : BaseResponseHandler<Get$domainName$ByIdQuery, Get$domainName$Dto>
    {
        private readonly I$domainName$Service _$domainNameLowerTitleCase$Service;

        public Get$domainName$ByIdQueryHandler(
            ILogger<Get$domainName$ByIdQuery> logger, I$domainName$Service $domainNameLowerTitleCase$Service)
            : base(logger)
        {
            _$domainNameLowerTitleCase$Service = $domainNameLowerTitleCase$Service;
        }

        protected override async Task<Get$domainName$Dto> ExecuteAsync(Get$domainName$ByIdQuery request, CancellationToken ct)
        {
            return await _$domainNameLowerTitleCase$Service.GetByIdAsync(request.Id, ct);
        }
    }
}