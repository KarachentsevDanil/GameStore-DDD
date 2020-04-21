using AutoMapper;
using FluentValidation;
using GSP.Rate.Application.CQS.Commands.Rates;
using GSP.Rate.Application.UseCases.DTOs.Rates;
using GSP.Rate.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Rate.Application.CQS.Handlers.Commands.Rates
{
    public class CreateRateCommonHandler : BaseValidationResponseHandler<CreateRateCommand, GetRateDto>
    {
        private readonly IMapper _mapper;

        private readonly IRateService _rateService;

        public CreateRateCommonHandler(
            IValidator<CreateRateCommand> validator,
            ILogger<CreateRateCommand> logger,
            IMapper mapper,
            IRateService rateService)
            : base(validator, logger)
        {
            _mapper = mapper;
            _rateService = rateService;
        }

        protected override async Task<GetRateDto> ExecuteAsync(CreateRateCommand request, CancellationToken ct)
        {
            AddRateDto accountDto = _mapper.Map<AddRateDto>(request);
            return await _rateService.AddAsync(accountDto, ct);
        }
    }
}