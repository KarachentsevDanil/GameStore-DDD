using FluentValidation;
using GSP.Payment.Application.CQS.Commands.PaymentMethods;

namespace GSP.Payment.Application.CQS.Validations.PaymentMethods
{
    public class CreatePaymentMethodValidator : AbstractValidator<CreatePaymentMethodCommand>
    {
        public CreatePaymentMethodValidator()
        {
            RuleFor(p => p.AccountId)
                .GreaterThan(0);

            RuleFor(p => p.CardHolderFullName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(p => p.Expiration)
                .NotNull()
                .NotEmpty()
                .Length(7);

            RuleFor(p => p.CardNumber)
                .NotNull()
                .NotEmpty()
                .Length(16);

            RuleFor(p => p.Cvv)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(4);
        }
    }
}