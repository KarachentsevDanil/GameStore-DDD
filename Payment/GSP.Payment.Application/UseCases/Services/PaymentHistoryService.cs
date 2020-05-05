using AutoMapper;
using GSP.Payment.Application.UseCases.DTOs.PaymentHistories;
using GSP.Payment.Application.UseCases.Exceptions;
using GSP.Payment.Application.UseCases.Services.Contracts;
using GSP.Payment.Domain.Entities;
using GSP.Payment.Domain.Models;
using GSP.Payment.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.Application.UseCases.Exceptions;
using GSP.Shared.Utils.Common.Helpers;
using GSP.Shared.Utils.Common.Models.Collections;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Payment.Application.UseCases.Services
{
    public class PaymentHistoryService : IPaymentHistoryService
    {
        private readonly IPaymentUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public PaymentHistoryService(IPaymentUnitOfWork unitOfWork, IMapper mapper, ILogger<PaymentHistoryService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetPaymentHistoryDto> AddAsync(AddPaymentHistoryDto addPaymentHistoryDto, CancellationToken ct = default)
        {
            _logger.LogInformation(
                "Pay order with {PaymentMethodId} for account {AccountId}",
                addPaymentHistoryDto.PaymentMethodId,
                addPaymentHistoryDto.AccountId);

            await ValidatePaymentHistoryAddingAsync(addPaymentHistoryDto, ct);

            var paymentHistory = PaymentHistory.Create(
                addPaymentHistoryDto.AccountId,
                addPaymentHistoryDto.OrderId,
                addPaymentHistoryDto.PaymentMethodId,
                addPaymentHistoryDto.Amount);

            _unitOfWork.PaymentHistoryRepository.Create(paymentHistory);

            await _unitOfWork.SaveAsync(ct);

            return _mapper.Map<GetPaymentHistoryDto>(paymentHistory);
        }

        public async Task<PagedCollection<GetPaymentHistoryDto>> GetListByFilterParamsAsync(PaymentHistoryFilterParams filterParams, CancellationToken ct = default)
        {
            _logger.LogInformation("Get payment histories by filter params {@FilterParams}", filterParams);

            var items = await _unitOfWork.PaymentHistoryRepository.GetListByAccountIdAsync(filterParams, ct);

            var result = new PagedCollection<GetPaymentHistoryDto>(
                _mapper.Map<IEnumerable<GetPaymentHistoryDto>>(items.Items), items.TotalCount);

            return result;
        }

        private async Task ValidatePaymentHistoryAddingAsync(AddPaymentHistoryDto paymentHistoryDto, CancellationToken ct)
        {
            var paymentMethodDto = await _unitOfWork.PaymentMethodRepository.GetAsync(paymentHistoryDto.PaymentMethodId, ct);

            if (paymentMethodDto == null)
            {
                _logger.LogInformation("Payment method with id {PaymentMethodId} not found", paymentHistoryDto.PaymentMethodId);
                throw new ItemNotFoundException();
            }

            if (paymentMethodDto.AccountId != paymentHistoryDto.AccountId)
            {
                _logger.LogInformation("Access to this payment method is not allowed for account {AccountId}", paymentHistoryDto.AccountId);
                throw new AccessToItemForbiddenException();
            }

            var isAlreadyPaid =
                await _unitOfWork.PaymentHistoryRepository.IsExistsAsync(paymentMethodDto.AccountId, paymentHistoryDto.OrderId, ct);

            if (isAlreadyPaid)
            {
                _logger.LogInformation("Order with Id {OrderId} already paid", paymentHistoryDto.OrderId);
                throw new OrderAlreadyPaidException();
            }

            if (paymentMethodDto.Cvv != StringEncryptionHelper.Encrypt(paymentHistoryDto.Cvv))
            {
                _logger.LogInformation("Cvv code for payment method {PaymentMethodId} is wrong", paymentHistoryDto.PaymentMethodId);
                throw new CvvIsWrongException();
            }
        }
    }
}