using FluentValidation;
using GSP.Account.Application.CQS.Commands;

namespace GSP.Account.Application.CQS.Validators
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