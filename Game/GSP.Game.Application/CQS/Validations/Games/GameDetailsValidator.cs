using FluentValidation;
using GSP.Game.Application.UseCases.DTOs.Games;

namespace GSP.Game.Application.CQS.Validations.Games
{
    public class GameDetailsValidator : AbstractValidator<GameDetailsDto>
    {
        public GameDetailsValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(p => p.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(p => p.Price)
                .GreaterThan(0);

            RuleFor(p => p.PhotoUri)
                .NotNull();

            RuleFor(p => p.IconUri)
                .NotNull();
        }
    }
}