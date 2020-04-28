using GSP.Payment.Application.CQS.Queries.PaymentMethods;
using GSP.Payment.Application.UseCases.DTOs.PaymentMethods;
using GSP.Payment.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Payment.Application.CQS.Handlers.Queries.PaymentMethods
{
    public class GetPaymentMethodsQueryHandler : BaseResponseHandler<GetPaymentMethodsQuery, IImmutableList<GetPaymentMethodDto>>
    {
        private readonly IPaymentMethodService _paymentMethodService;

        public GetPaymentMethodsQueryHandler(
            ILogger<GetPaymentMethodsQuery> logger,
            IPaymentMethodService paymentMethodService)
            : base(logger)
        {
            _paymentMethodService = paymentMethodService;
        }

        protected override async Task<IImmutableList<GetPaymentMethodDto>> ExecuteAsync(GetPaymentMethodsQuery request, CancellationToken ct)
        {
            return await _paymentMethodService.GetListByAccountIdAsync(request.AccountId, ct);
        }
    }
}