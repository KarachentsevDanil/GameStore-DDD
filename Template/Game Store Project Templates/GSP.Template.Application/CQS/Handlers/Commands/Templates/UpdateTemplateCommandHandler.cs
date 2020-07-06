using AutoMapper;
using FluentValidation;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using GSP.Template.Application.CQS.Commands.Templates;
using GSP.Template.Application.UseCases.DTOs.Templates;
using GSP.Template.Application.UseCases.Services.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Template.Application.CQS.Handlers.Commands.Templates
{
    public class UpdateTemplateCommandHandler : BaseValidationResponseHandler<UpdateTemplateCommand, GetTemplateDto>
    {
        private readonly IMapper _mapper;

        private readonly ITemplateService _service;

        public UpdateTemplateCommandHandler(
            IValidator validator, ILogger<UpdateTemplateCommand> logger, IMapper mapper, ITemplateService service)
            : base(validator, logger)
        {
            _mapper = mapper;
            _service = service;
        }

        protected override async Task<GetTemplateDto> ExecuteAsync(UpdateTemplateCommand request, CancellationToken ct)
        {
            return await _service.UpdateAsync(_mapper.Map<UpdateTemplateDto>(request), ct);
        }
    }
}