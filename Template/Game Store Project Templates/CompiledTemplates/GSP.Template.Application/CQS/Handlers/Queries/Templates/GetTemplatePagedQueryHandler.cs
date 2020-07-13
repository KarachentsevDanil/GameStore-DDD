using AutoMapper;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.Models.Collections;
using $safeprojectname$.CQS.Queries.$domainName$s;
using $safeprojectname$.UseCases.DTOs.$domainName$s;
using $safeprojectname$.UseCases.Services.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.CQS.Handlers.Queries.$domainName$s
{
    public class Get$domainName$PagedQueryHandler : BaseResponseHandler<Get$domainName$PagedQuery, PagedCollection<Get$domainName$Dto>>
    {
        private readonly I$domainName$Service _$domainNameLowerTitleCase$Service;

        public Get$domainName$PagedQueryHandler(
            ILogger<Get$domainName$PagedQuery> logger, I$domainName$Service $domainNameLowerTitleCase$Service)
            : base(logger)
        {
            _$domainNameLowerTitleCase$Service = $domainNameLowerTitleCase$Service;
        }

        protected override async Task<PagedCollection<Get$domainName$Dto>> ExecuteAsync(Get$domainName$PagedQuery request, CancellationToken ct)
        {
            return await _$domainNameLowerTitleCase$Service.GetPagedListAsync(request.ToPaginationFilterParams(), ct);
        }
    }
}