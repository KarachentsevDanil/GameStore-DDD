using FluentValidation;
using GSP.Game.Application.CQS.Commands.DeveloperStudios;

namespace GSP.Game.Application.CQS.Validations.DeveloperStudios
{
    public class UpdateDeveloperStudioValidator : AbstractValidator<UpdateDeveloperStudioCommand>
    {
        public UpdateDeveloperStudioValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0);

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