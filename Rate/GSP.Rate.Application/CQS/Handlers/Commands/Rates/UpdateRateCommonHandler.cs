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
    public class UpdateRateCommonHandler : BaseValidationResponseHandler<UpdateRateCommand, GetRateDto>
    {
        private readonly IMapper _mapper;

        private readonly IRateService _rateService;

        public UpdateRateCommonHandler(
            IValidator<UpdateRateCommand> validator,
            ILogger<UpdateRateCommand> logger,
            IMapper mapper,
            IRateService rateService)
            : base(validator, logger)
        {
            _mapper = mapper;
            _rateService = rateService;
        }

        protected override async Task<GetRateDto> ExecuteAsync(UpdateRateCommand request, CancellationToken ct)
        {
            UpdateRateDto accountDto = _mapper.Map<UpdateRateDto>(request);
            return await _rateService.UpdateAsync(accountDto, ct);
        }
    }
}