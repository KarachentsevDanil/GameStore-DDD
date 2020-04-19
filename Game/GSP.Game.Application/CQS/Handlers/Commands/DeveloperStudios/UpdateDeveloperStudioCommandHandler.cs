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
    public class UpdateDeveloperStudioCommandHandler : BaseValidationResponseHandler<UpdateDeveloperStudioCommand, GetDeveloperStudioDto>
    {
        private readonly IMapper _mapper;

        private readonly IDeveloperStudioService _developerStudioService;

        public UpdateDeveloperStudioCommandHandler(
            AbstractValidator<UpdateDeveloperStudioCommand> validator,
            ILogger<UpdateDeveloperStudioCommand> logger,
            IMapper mapper,
            IDeveloperStudioService developerStudioService)
            : base(validator, logger)
        {
            _mapper = mapper;
            _developerStudioService = developerStudioService;
        }

        protected override async Task<GetDeveloperStudioDto> ExecuteAsync(UpdateDeveloperStudioCommand request, CancellationToken ct)
        {
            return await _developerStudioService.UpdateAsync(_mapper.Map<UpdateDeveloperStudioDto>(request), ct);
        }
    }
}