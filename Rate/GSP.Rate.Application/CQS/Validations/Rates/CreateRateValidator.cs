using FluentValidation;
using GSP.Rate.Application.CQS.Commands.Rates;

namespace GSP.Rate.Application.CQS.Validations.Rates
{
    public class CreateRateValidator : AbstractValidator<CreateRateCommand>
    {
        public CreateRateValidator()
        {
            RuleFor(r => r.GameId)
                .GreaterThan(0);

            RuleFor(r => r.AccountId)
                .GreaterThan(0);

            RuleFor(r => r.Comment)
                .NotNull()
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(r => r.Rating)
                .GreaterThan(0)
                .LessThanOrEqualTo(10);
        }
    }
}