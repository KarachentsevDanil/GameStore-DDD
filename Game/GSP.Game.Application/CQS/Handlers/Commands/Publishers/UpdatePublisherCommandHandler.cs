using AutoMapper;
using FluentValidation;
using GSP.Game.Application.CQS.Commands.Publishers;
using GSP.Game.Application.UseCases.DTOs.Publishers;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Handlers.Commands.Publishers
{
    public class UpdatePublisherCommandHandler : BaseValidationResponseHandler<UpdatePublisherCommand, GetPublisherDto>
    {
        private readonly IMapper _mapper;

        private readonly IPublisherService _service;

        public UpdatePublisherCommandHandler(
            AbstractValidator<UpdatePublisherCommand> validator,
            ILogger<UpdatePublisherCommand> logger,
            IMapper mapper,
            IPublisherService service)
            : base(validator, logger)
        {
            _mapper = mapper;
            _service = service;
        }

        protected override async Task<GetPublisherDto> ExecuteAsync(UpdatePublisherCommand request, CancellationToken ct)
        {
            return await _service.UpdateAsync(_mapper.Map<UpdatePublisherDto>(request), ct);
        }
    }
}