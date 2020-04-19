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
    public class UpdateGenreCommandHandler : BaseValidationResponseHandler<UpdateGenreCommand, GetGenreDto>
    {
        private readonly IMapper _mapper;

        private readonly IGenreService _genreService;

        public UpdateGenreCommandHandler(
            AbstractValidator<UpdateGenreCommand> validator,
            ILogger<UpdateGenreCommand> logger,
            IMapper mapper,
            IGenreService genreService)
            : base(validator, logger)
        {
            _mapper = mapper;
            _genreService = genreService;
        }

        protected override async Task<GetGenreDto> ExecuteAsync(UpdateGenreCommand request, CancellationToken ct)
        {
            return await _genreService.UpdateAsync(_mapper.Map<UpdateGenreDto>(request), ct);
        }
    }
}