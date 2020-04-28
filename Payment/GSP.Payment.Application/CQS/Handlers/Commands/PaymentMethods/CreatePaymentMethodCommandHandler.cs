using AutoMapper;
using FluentValidation;
using GSP.Payment.Application.CQS.Commands.PaymentMethods;
using GSP.Payment.Application.UseCases.DTOs.PaymentMethods;
using GSP.Payment.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Payment.Application.CQS.Handlers.Commands.PaymentMethods
{
    public class CreatePaymentMethodCommandHandler :
        BaseValidationResponseHandler<CreatePaymentMethodCommand, GetPaymentMethodDto>
    {
        private readonly IPaymentMethodService _paymentMethodService;

        private readonly IMapper _mapper;

        public CreatePaymentMethodCommandHandler(
            IValidator<CreatePaymentMethodCommand> validator,
            ILogger<CreatePaymentMethodCommand> logger,
            IPaymentMethodService paymentMethodService,
            IMapper mapper)
            : base(validator, logger)
        {
            _paymentMethodService = paymentMethodService;
            _mapper = mapper;
        }

        protected override async Task<GetPaymentMethodDto> ExecuteAsync(CreatePaymentMethodCommand request, CancellationToken ct)
        {
            AddPaymentMethodDto paymentMethodDto = _mapper.Map<AddPaymentMethodDto>(request);

            return await _paymentMethodService.AddAsync(paymentMethodDto, ct);
        }
    }
}