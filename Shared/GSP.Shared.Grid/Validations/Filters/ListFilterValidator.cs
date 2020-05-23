using FluentValidation;
using GSP.Shared.Grid.Filters.Contracts;

namespace GSP.Shared.Grid.Validations.Filters
{
    public class ListFilterValidator<TFilter> : AbstractValidator<TFilter>
        where TFilter : IFilter
    {
        public ListFilterValidator()
        {
            RuleFor(p => p.ListFilterOption)
                .NotNull()
                .IsInEnum();

            RuleForEach(p => p.Values)
                .NotNull()
                .NotEmpty();
        }
    }
}