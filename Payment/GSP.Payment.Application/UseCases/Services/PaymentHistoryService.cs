using AutoMapper;
using GSP.Payment.Application.UseCases.DTOs.PaymentHistories;
using GSP.Payment.Application.UseCases.Services.Contracts;
using GSP.Payment.Domain.Models;
using GSP.Payment.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.Common.Models.Collections;
using Microsoft.Extensions.Logging;
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

        public Task<GetPaymentHistoryDto> AddAsync(AddPaymentHistoryDto addPaymentHistoryDto, CancellationToken ct = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedCollection<GetPaymentHistoryDto>> GetListByFilterParamsAsync(PaymentHistoryFilterParams filterParams, CancellationToken ct = default)
        {
            throw new System.NotImplementedException();
        }
    }
}