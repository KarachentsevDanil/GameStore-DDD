using AutoMapper;
using GSP.Payment.Application.UseCases.DTOs.PaymentMethods;
using GSP.Payment.Application.UseCases.Services.Contracts;
using GSP.Payment.Domain.UnitOfWorks.Contracts;
using Microsoft.Extensions.Logging;
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

        public Task<GetPaymentMethodDto> AddAsync(AddPaymentMethodDto addPaymentMethodDto, CancellationToken ct = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IImmutableList<GetPaymentMethodDto>> GetListByAccountIdAsync(long accountId, CancellationToken ct = default)
        {
            throw new System.NotImplementedException();
        }
    }
}