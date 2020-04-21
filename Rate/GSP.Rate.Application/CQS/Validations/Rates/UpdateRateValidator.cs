using FluentValidation;
using GSP.Rate.Application.CQS.Commands.Rates;

namespace GSP.Rate.Application.CQS.Validations.Rates
{
    public class UpdateRateValidator : AbstractValidator<UpdateRateCommand>
    {
        public UpdateRateValidator()
        {
            RuleFor(r => r.Id)
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