using FluentValidation;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;

namespace GSP.Shared.Grid.Validations.Filters
{
    public class NumberFilterValidator<TFilter> : AbstractValidator<TFilter>
        where TFilter : IFilter
    {
        public NumberFilterValidator()
        {
            RuleFor(p => p.NumberFilterOption)
                .NotNull()
                .IsInEnum();

            RuleFor(p => p.Value)
                .NotNull()
                .NotEmpty()
                .When(p => p.NumberFilterOption != NumberFilterOption.Between);

            RuleFor(p => p.FirstOperand)
                .NotNull()
                .NotEmpty()
                .When(p => p.NumberFilterOption == NumberFilterOption.Between);

            RuleFor(p => p.SecondOperand)
                .NotNull()
                .NotEmpty()
                .When(p => p.NumberFilterOption == NumberFilterOption.Between);
        }
    }
}