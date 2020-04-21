using AutoMapper;
using GSP.Rate.Application.CQS.Queries.Rates;
using GSP.Rate.Application.UseCases.DTOs.Rates;
using GSP.Rate.Application.UseCases.Services.Contracts;
using GSP.Rate.Domain.Models;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.Models.Collections;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Rate.Application.CQS.Handlers.Queries.Rates
{
    public class GetRateListQueryHandler : BaseResponseHandler<GetRateListQuery, PagedCollection<GetRateDto>>
    {
        private readonly IMapper _mapper;

        private readonly IRateService _accountService;

        public GetRateListQueryHandler(ILogger<GetRateListQuery> logger, IMapper mapper, IRateService accountService)
            : base(logger)
        {
            _mapper = mapper;
            _accountService = accountService;
        }

        protected override async Task<PagedCollection<GetRateDto>> ExecuteAsync(GetRateListQuery request, CancellationToken ct)
        {
            RateFilterParams filterParams = _mapper.Map<RateFilterParams>(request);
            return await _accountService.GetListByFilterParamsAsync(filterParams, ct);
        }
    }
}