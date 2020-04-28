using AutoMapper;
using FluentValidation;
using GSP.Payment.Application.CQS.Commands.PaymentHistories;
using GSP.Payment.Application.UseCases.DTOs.PaymentHistories;
using GSP.Payment.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Payment.Application.CQS.Handlers.Commands.PaymentHistories
{
    public class CreatePaymentHistoryCommandHandler :
        BaseValidationResponseHandler<CreatePaymentHistoryCommand, GetPaymentHistoryDto>
    {
        private readonly IPaymentHistoryService _paymentHistoryService;

        private readonly IMapper _mapper;

        public CreatePaymentHistoryCommandHandler(
            IValidator<CreatePaymentHistoryCommand> validator,
            ILogger<CreatePaymentHistoryCommand> logger,
            IPaymentHistoryService paymentHistoryService,
            IMapper mapper)
            : base(validator, logger)
        {
            _paymentHistoryService = paymentHistoryService;
            _mapper = mapper;
        }

        protected override async Task<GetPaymentHistoryDto> ExecuteAsync(CreatePaymentHistoryCommand request, CancellationToken ct)
        {
            AddPaymentHistoryDto paymentHistoryDto = _mapper.Map<AddPaymentHistoryDto>(request);

            return await _paymentHistoryService.AddAsync(paymentHistoryDto, ct);
        }
    }
}