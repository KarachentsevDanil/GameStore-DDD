using AutoMapper;
using FluentValidation;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Shared.Utils.Common.ServiceBus.Base.Contracts;
using GSP.Template.Application.CQS.Bus;
using GSP.Template.Application.CQS.Bus.Messages;
using GSP.Template.Application.CQS.Commands.Templates;
using GSP.Template.Application.UseCases.DTOs.Templates;
using GSP.Template.Application.UseCases.Services.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Template.Application.CQS.Handlers.Commands.Templates
{
    public class AddTemplateCommandHandler : BaseValidationResponseHandler<AddTemplateCommand, GetTemplateDto>
    {
        private readonly IMapper _mapper;

        private readonly ITemplateService _service;

        private readonly IServiceBusClient _serviceBusClient;

        public AddTemplateCommandHandler(
            IValidator validator,
            ILogger<AddTemplateCommand> logger,
            IMapper mapper,
            ITemplateService service,
            IServiceBusClient serviceBusClient)
            : base(validator, logger)
        {
            _mapper = mapper;
            _service = service;
            _serviceBusClient = serviceBusClient;
        }

        protected override async Task<GetTemplateDto> ExecuteAsync(AddTemplateCommand request, CancellationToken ct)
        {
            var createdTemplate = await _service.AddAsync(_mapper.Map<AddTemplateDto>(request), ct);

            await _serviceBusClient.PublishTemplateCreatedAsync(
                new TemplateCreatedMessage(createdTemplate.Id, createdTemplate.Name));

            return createdTemplate;
        }
    }
}