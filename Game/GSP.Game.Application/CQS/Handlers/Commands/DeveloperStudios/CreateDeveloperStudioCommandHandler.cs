using AutoMapper;
using FluentValidation;
using GSP.Game.Application.CQS.Commands.DeveloperStudios;
using GSP.Game.Application.UseCases.DTOs.DeveloperStudios;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Handlers.Commands.DeveloperStudios
{
    public class CreateDeveloperStudioCommandHandler : BaseValidationResponseHandler<CreateDeveloperStudioCommand, GetDeveloperStudioDto>
    {
        private readonly IMapper _mapper;

        private readonly IDeveloperStudioService _developerStudioService;

        public CreateDeveloperStudioCommandHandler(
            AbstractValidator<CreateDeveloperStudioCommand> validator,
            ILogger<CreateDeveloperStudioCommand> logger,
            IMapper mapper,
            IDeveloperStudioService developerStudioService)
            : base(validator, logger)
        {
            _mapper = mapper;
            _developerStudioService = developerStudioService;
        }

        protected override async Task<GetDeveloperStudioDto> ExecuteAsync(CreateDeveloperStudioCommand request, CancellationToken ct)
        {
            return await _developerStudioService.AddAsync(_mapper.Map<AddDeveloperStudioDto>(request), ct);
        }
    }
}