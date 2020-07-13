using AutoMapper;
using FluentValidation;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using $safeprojectname$.CQS.Commands.$domainName$s;
using $safeprojectname$.UseCases.DTOs.$domainName$s;
using $safeprojectname$.UseCases.Services.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.CQS.Handlers.Commands.$domainName$s
{
    public class Update$domainName$CommandHandler : BaseValidationResponseHandler<Update$domainName$Command, Get$domainName$Dto>
    {
        private readonly IMapper _mapper;

        private readonly I$domainName$Service _service;

        public Update$domainName$CommandHandler(
            IValidator validator, ILogger<Update$domainName$Command> logger, IMapper mapper, I$domainName$Service service)
            : base(validator, logger)
        {
            _mapper = mapper;
            _service = service;
        }

        protected override async Task<Get$domainName$Dto> ExecuteAsync(Update$domainName$Command request, CancellationToken ct)
        {
            return await _service.UpdateAsync(_mapper.Map<Update$domainName$Dto>(request), ct);
        }
    }
}