using FluentValidation;
using GSP.Game.Application.CQS.Commands.Games;
using GSP.Game.Application.UseCases.Services.Contracts;

namespace GSP.Game.Application.CQS.Validations.Games
{
    public class UpdateGameValidator : AbstractValidator<UpdateGameCommand>
    {
        public UpdateGameValidator(IGenreService genreService, IDeveloperStudioService developerStudioService, IPublisherService publisherService)
        {
            RuleFor(p => p.Id)
                .GreaterThan(0);

            RuleFor(p => p.DeveloperStudioId)
                .GreaterThan(0)
                .MustAsync(async (d, developerStudioId, token) =>
                    await developerStudioService.IsExistAsync(developerStudioId, token))
                .WithMessage(t => $"Developer studio with Id {t.DeveloperStudioId} doesn't exist");

            RuleFor(p => p.GenreId)
                .GreaterThan(0)
                .MustAsync(async (g, genreId, token) =>
                    await genreService.IsExistAsync(genreId, token))
                .WithMessage(t => $"Genre with Id {t.GenreId} doesn't exist");

            RuleFor(p => p.PublisherId)
                .GreaterThan(0)
                .MustAsync(async (p, publisherId, token) =>
                    await publisherService.IsExistAsync(publisherId, token))
                .WithMessage(t => $"Publisher with Id {t.PublisherId} doesn't exist");

            RuleFor(p => p.GameDetails)
                .NotNull()
                .SetValidator(new GameDetailsValidator());

            RuleForEach(p => p.Attachments)
                .SetValidator(new GameAttachmentValidator());
        }
    }
}