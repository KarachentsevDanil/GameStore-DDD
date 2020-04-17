using FluentValidation;
using GSP.Account.WebApi.Commands;

namespace GSP.Account.WebApi.Validators
{
    public class UpdateAccountValidator : AbstractValidator<UpdateAccountCommand>
    {
        public UpdateAccountValidator()
        {
            RuleFor(t => t.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(t => t.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}