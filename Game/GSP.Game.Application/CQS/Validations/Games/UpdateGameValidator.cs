using FluentValidation;
using GSP.Game.Application.UseCases.DTOs.Games;

namespace GSP.Game.Application.CQS.Validations.Games
{
    public class UpdateGameValidator : AbstractValidator<UpdateGameDto>
    {
        public UpdateGameValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0);

            RuleFor(p => p.DeveloperStudioId)
                .GreaterThan(0);

            RuleFor(p => p.GenreId)
                .GreaterThan(0);

            RuleFor(p => p.PublisherId)
                .GreaterThan(0);

            RuleFor(p => p.GameDetails)
                .NotNull()
                .SetValidator(new GameDetailsValidator());

            RuleForEach(p => p.Attachments)
                .SetValidator(new GameAttachmentValidator());
        }
    }
}