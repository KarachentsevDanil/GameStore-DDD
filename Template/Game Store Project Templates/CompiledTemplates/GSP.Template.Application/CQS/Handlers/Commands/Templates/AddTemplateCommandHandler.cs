using AutoMapper;
using FluentValidation;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.EventBus.Base.Contracts;
using $safeprojectname$.CQS.Bus;
using $safeprojectname$.CQS.Bus.Messages;
using $safeprojectname$.CQS.Commands.$domainName$s;
using $safeprojectname$.UseCases.DTOs.$domainName$s;
using $safeprojectname$.UseCases.Services.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.CQS.Handlers.Commands.$domainName$s
{
    public class Add$domainName$CommandHandler : BaseValidationResponseHandler<Add$domainName$Command, Get$domainName$Dto>
    {
        private readonly IMapper _mapper;

        private readonly I$domainName$Service _service;

        private readonly IServiceBusClient _serviceBusClient;

        public Add$domainName$CommandHandler(
            IValidator validator,
            ILogger<Add$domainName$Command> logger,
            IMapper mapper,
            I$domainName$Service service,
            IServiceBusClient serviceBusClient)
            : base(validator, logger)
        {
            _mapper = mapper;
            _service = service;
            _serviceBusClient = serviceBusClient;
        }

        protected override async Task<Get$domainName$Dto> ExecuteAsync(Add$domainName$Command request, CancellationToken ct)
        {
            var created$domainName$ = await _service.AddAsync(_mapper.Map<Add$domainName$Dto>(request), ct);

            await _serviceBusClient.Publish$domainName$CreatedAsync(
                new $domainName$CreatedMessage(created$domainName$.Id, created$domainName$.Name));

            return created$domainName$;
        }
    }
}