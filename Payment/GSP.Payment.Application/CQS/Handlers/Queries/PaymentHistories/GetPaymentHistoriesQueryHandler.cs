using AutoMapper;
using GSP.Payment.Application.CQS.Queries.PaymentHistories;
using GSP.Payment.Application.UseCases.DTOs.PaymentHistories;
using GSP.Payment.Application.UseCases.Services.Contracts;
using GSP.Payment.Domain.Models;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.Models.Collections;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Payment.Application.CQS.Handlers.Queries.PaymentHistories
{
    public class GetPaymentHistoriesQueryHandler : BaseResponseHandler<GetPaymentHistoriesQuery, PagedCollection<GetPaymentHistoryDto>>
    {
        private readonly IPaymentHistoryService _paymentHistoryService;

        private readonly IMapper _mapper;

        public GetPaymentHistoriesQueryHandler(
            ILogger<GetPaymentHistoriesQuery> logger,
            IPaymentHistoryService paymentHistoryService,
            IMapper mapper)
            : base(logger)
        {
            _paymentHistoryService = paymentHistoryService;
            _mapper = mapper;
        }

        protected override async Task<PagedCollection<GetPaymentHistoryDto>> ExecuteAsync(GetPaymentHistoriesQuery request, CancellationToken ct)
        {
            var query = _mapper.Map<PaymentHistoryFilterParams>(request);

            return await _paymentHistoryService.GetListByFilterParamsAsync(query, ct);
        }
    }
}