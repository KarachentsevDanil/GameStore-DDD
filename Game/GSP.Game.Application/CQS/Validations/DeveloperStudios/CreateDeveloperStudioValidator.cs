using FluentValidation;
using GSP.Game.Application.CQS.Commands.DeveloperStudios;

namespace GSP.Game.Application.CQS.Validations.DeveloperStudios
{
    public class CreateDeveloperStudioValidator : AbstractValidator<CreateDeveloperStudioCommand>
    {
        public CreateDeveloperStudioValidator()
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