using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Data.Grid.Models;
using $safeprojectname$.CQS.Queries.$domainName$s;
using $safeprojectname$.UseCases.Services.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.CQS.Handlers.Queries.$domainName$s
{
    public class Get$domainName$GridQueryHandler : BaseResponseHandler<Get$domainName$GridQuery, GridModel>
    {
        private readonly I$domainName$Service _$domainNameLowerTitleCase$Service;

        public Get$domainName$GridQueryHandler(
            ILogger<Get$domainName$GridQuery> logger, I$domainName$Service $domainNameLowerTitleCase$Service)
            : base(logger)
        {
            _$domainNameLowerTitleCase$Service = $domainNameLowerTitleCase$Service;
        }

        protected override async Task<GridModel> ExecuteAsync(Get$domainName$GridQuery request, CancellationToken ct)
        {
            return await _$domainNameLowerTitleCase$Service.GetGridAsync(request.Grid, ct);
        }
    }
}