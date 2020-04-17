using FluentValidation;
using GSP.Account.WebApi.Commands;

namespace GSP.Account.WebApi.Validators
{
    public class LoginValidator : AbstractValidator<LoginToAccountCommand>
    {
        public LoginValidator()
        {
            RuleFor(t => t.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(255);

            RuleFor(t => t.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(20);
        }
    }
}