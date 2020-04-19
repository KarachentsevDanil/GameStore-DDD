using FluentValidation;
using GSP.Game.Application.CQS.Commands.Publishers;

namespace GSP.Game.Application.CQS.Validations.Publishers
{
    public class CreatePublisherValidator : AbstractValidator<CreatePublisherCommand>
    {
        public CreatePublisherValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(p => p.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(p => p.LogoUri)
                .NotNull();

            RuleFor(p => p.WebPageUri)
                .NotNull();
        }
    }
}