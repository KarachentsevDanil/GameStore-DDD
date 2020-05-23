using FluentValidation;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums;

namespace GSP.Shared.Grid.Validations.Filters
{
    public class BaseFilterValidator<TFilter> : AbstractValidator<TFilter>
        where TFilter : IFilter
    {
        public BaseFilterValidator()
        {
            RuleFor(p => p.Type)
                .IsInEnum();

            RuleFor(p => p)
                .SetValidator(new BooleanFilterValidator<TFilter>())
                .When(t => t.Type == GridFilterType.Number);

            RuleFor(p => p)
                .SetValidator(new DateFilterValidator<TFilter>())
                .When(t => t.Type == GridFilterType.Date);

            RuleFor(p => p)
                .SetValidator(new ListFilterValidator<TFilter>())
                .When(t => t.Type == GridFilterType.List);

            RuleFor(p => p)
                .SetValidator(new NumberFilterValidator<TFilter>())
                .When(t => t.Type == GridFilterType.Number);

            RuleFor(p => p)
                .SetValidator(new TextFilterValidator<TFilter>())
                .When(t => t.Type == GridFilterType.Text);
        }
    }
}