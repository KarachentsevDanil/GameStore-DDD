using FluentValidation;
using GSP.Game.Application.UseCases.DTOs.Games;

namespace GSP.Game.Application.CQS.Validations.Games
{
    public class GameAttachmentValidator : AbstractValidator<GameAttachmentDto>
    {
        public GameAttachmentValidator()
        {
            RuleFor(p => p.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(p => p.LinkUri)
                .NotNull();
        }
    }
}