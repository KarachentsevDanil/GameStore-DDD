using FluentValidation;
using GSP.Account.Application.CQS.Commands;

namespace GSP.Account.Application.CQS.Validators
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