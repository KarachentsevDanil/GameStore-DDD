using FluentValidation;
using GSP.Game.Application.CQS.Commands.Genres;

namespace GSP.Game.Application.CQS.Validations.Genres
{
    public class CreateGenreValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(p => p.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(500);
        }
    }
}