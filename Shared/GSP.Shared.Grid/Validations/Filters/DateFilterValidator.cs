using FluentValidation;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums.FilterOptions;

namespace GSP.Shared.Grid.Validations.Filters
{
    public class DateFilterValidator<TFilter> : AbstractValidator<TFilter>
        where TFilter : IFilter
    {
        public DateFilterValidator()
        {
            RuleFor(p => p.DateFilterOption)
                .NotNull()
                .IsInEnum();

            RuleFor(p => p.SelectedStartDate)
                .NotNull()
                .When(p => p.DateFilterOption == DateFilterOption.DateRange);

            RuleFor(p => p.SelectedEndDate)
                .NotNull()
                .When(p => p.DateFilterOption == DateFilterOption.DateRange);
        }
    }
}