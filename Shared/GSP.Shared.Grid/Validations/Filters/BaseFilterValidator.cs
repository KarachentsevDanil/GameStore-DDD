using FluentValidation;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums;
using GSP.Shared.Grid.Models;

namespace GSP.Shared.Grid.Validations.Filters
{
    public class BaseFilterValidator<TFilter> : AbstractValidator<TFilter>
        where TFilter : IFilter
    {
        public BaseFilterValidator(GridTypeModel gridTypeModel)
        {
            RuleFor(p => p.Type)
                .IsInEnum();

            RuleFor(p => p)
                .SetValidator(new BooleanFilterValidator<TFilter>(gridTypeModel))
                .When(t => t.Type == GridFilterType.Boolean);

            RuleFor(p => p)
                .SetValidator(new DateFilterValidator<TFilter>(gridTypeModel))
                .When(t => t.Type == GridFilterType.Date);

            RuleFor(p => p)
                .SetValidator(new ListFilterValidator<TFilter>(gridTypeModel))
                .When(t => t.Type == GridFilterType.List);

            RuleFor(p => p)
                .SetValidator(new NumberFilterValidator<TFilter>(gridTypeModel))
                .When(t => t.Type == GridFilterType.Number);

            RuleFor(p => p)
                .SetValidator(new TextFilterValidator<TFilter>(gridTypeModel))
                .When(t => t.Type == GridFilterType.Text);
        }
    }
}