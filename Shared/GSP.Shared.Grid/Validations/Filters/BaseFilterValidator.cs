using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Filters.Enums;
using GSP.Shared.Grid.Stores.Models;

namespace GSP.Shared.Grid.Validations.Filters
{
    public class BaseFilterValidator<TEntity> : AbstractValidator<IFilter<TEntity>>
    {
        public BaseFilterValidator(GridTypeModel gridTypeModel)
        {
            RuleFor(p => p.Type)
                .IsInEnum();

            RuleFor(p => p.PropertyName)
                .NotEmpty()
                .Must(p => IsFilteringAllowed(gridTypeModel, p))
                .WithMessage($"You can use only {gridTypeModel.PropertyNames.ToStringList()} properties for column.");

            RuleFor(p => p)
                .SetValidator(new BooleanFilterValidator<TEntity>(gridTypeModel))
                .When(t => t.Type == GridFilterType.Boolean);

            RuleFor(p => p)
                .SetValidator(new DateFilterValidator<TEntity>(gridTypeModel))
                .When(t => t.Type == GridFilterType.Date);

            RuleFor(p => p)
                .SetValidator(new ListFilterValidator<TEntity>(gridTypeModel))
                .When(t => t.Type == GridFilterType.List);

            RuleFor(p => p)
                .SetValidator(new NumberFilterValidator<TEntity>(gridTypeModel))
                .When(t => t.Type == GridFilterType.Number);

            RuleFor(p => p)
                .SetValidator(new TextFilterValidator<TEntity>(gridTypeModel))
                .When(t => t.Type == GridFilterType.Text);
        }

        private bool IsFilteringAllowed(GridTypeModel gridTypeModel, string propertyName)
        {
            return gridTypeModel.FilterablePropertyNames.Contains(propertyName);
        }
    }
}