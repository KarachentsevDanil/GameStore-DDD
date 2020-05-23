using FluentValidation;
using GSP.Shared.Grid.Filters.Contracts;

namespace GSP.Shared.Grid.Validations.Filters
{
    public class BooleanFilterValidator<TFilter> : AbstractValidator<TFilter>
        where TFilter : IFilter
    {
        public BooleanFilterValidator()
        {
            RuleFor(p => p.BooleanFilterOption)
                .NotNull()
                .IsInEnum();
        }
    }
}