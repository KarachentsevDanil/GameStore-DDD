using AutoMapper;
using FluentValidation;
using GSP.Game.Application.CQS.Commands.Genres;
using GSP.Game.Application.UseCases.DTOs.Genres;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.CQS.Handlers.Commands.Genres
{
    public class CreateGenreCommandHandler : BaseValidationResponseHandler<CreateGenreCommand, GetGenreDto>
    {
        private readonly IMapper _mapper;

        private readonly IGenreService _genreService;

        public CreateGenreCommandHandler(
            IValidator<CreateGenreCommand> validator,
            ILogger<CreateGenreCommand> logger,
            IMapper mapper,
            IGenreService genreService)
            : base(validator, logger)
        {
            _mapper = mapper;
            _genreService = genreService;
        }

        protected override async Task<GetGenreDto> ExecuteAsync(CreateGenreCommand request, CancellationToken ct)
        {
            return await _genreService.AddAsync(_mapper.Map<AddGenreDto>(request), ct);
        }
    }
}