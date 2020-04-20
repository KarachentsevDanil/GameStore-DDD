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
    public class CreatePublisherCommandHandler : BaseValidationResponseHandler<CreatePublisherCommand, GetPublisherDto>
    {
        private readonly IMapper _mapper;

        private readonly IPublisherService _service;

        public CreatePublisherCommandHandler(
            IValidator<CreatePublisherCommand> validator,
            ILogger<CreatePublisherCommand> logger,
            IMapper mapper,
            IPublisherService service)
            : base(validator, logger)
        {
            _mapper = mapper;
            _service = service;
        }

        protected override async Task<GetPublisherDto> ExecuteAsync(CreatePublisherCommand request, CancellationToken ct)
        {
            return await _service.AddAsync(_mapper.Map<AddPublisherDto>(request), ct);
        }
    }
}