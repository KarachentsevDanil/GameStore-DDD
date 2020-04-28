using AutoMapper;
using GSP.Payment.Application.UseCases.DTOs.PaymentMethods;
using GSP.Payment.Application.UseCases.Services.Contracts;
using GSP.Payment.Domain.Entities;
using GSP.Payment.Domain.UnitOfWorks.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Payment.Application.UseCases.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public PaymentMethodService(IPaymentUnitOfWork unitOfWork, IMapper mapper, ILogger<PaymentMethodService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetPaymentMethodDto> AddAsync(AddPaymentMethodDto addPaymentMethodDto, CancellationToken ct = default)
        {
            _logger.LogInformation("Add new payment method for account {AccountId}", addPaymentMethodDto.AccountId);

            PaymentMethod paymentMethod = PaymentMethod.Create(
                addPaymentMethodDto.AccountId,
                addPaymentMethodDto.CardNumber,
                addPaymentMethodDto.CardHolderFullName,
                addPaymentMethodDto.Expiration,
                addPaymentMethodDto.Cvv);

            _unitOfWork.PaymentMethodRepository.Create(paymentMethod);

            await _unitOfWork.SaveAsync(ct);

            return _mapper.Map<GetPaymentMethodDto>(paymentMethod);
        }

        public async Task<IImmutableList<GetPaymentMethodDto>> GetListByAccountIdAsync(long accountId, CancellationToken ct = default)
        {
            _logger.LogInformation("Get payment methods for account {AccountId}", accountId);

            var paymentMethods = await _unitOfWork.PaymentMethodRepository.GetListByAccountIdAsync(accountId, ct);

            return _mapper.Map<IEnumerable<GetPaymentMethodDto>>(paymentMethods).ToImmutableList();
        }
    }
}