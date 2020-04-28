using FluentValidation;
using GSP.Payment.Application.CQS.Commands.PaymentHistories;

namespace GSP.Payment.Application.CQS.Validations.PaymentHistories
{
    public class CreatePaymentHistoryValidator : AbstractValidator<CreatePaymentHistoryCommand>
    {
        public CreatePaymentHistoryValidator()
        {
            RuleFor(p => p.AccountId)
                .GreaterThan(0);

            RuleFor(p => p.OrderId)
                .GreaterThan(0);

            RuleFor(p => p.PaymentMethodId)
                .GreaterThan(0);

            RuleFor(p => p.Amount)
                .GreaterThan(0);

            RuleFor(p => p.Cvv)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(4);
        }
    }
}