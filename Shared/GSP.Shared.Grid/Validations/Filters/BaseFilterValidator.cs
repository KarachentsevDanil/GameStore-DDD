using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Models.Filters;
using GSP.Shared.Grid.Models.Filters.Enums;
using GSP.Shared.Grid.Stores.Models;

namespace GSP.Shared.Grid.Validations.Filters
{
    public class BaseFilterValidator : AbstractValidator<Filter>
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
                .SetValidator(new BooleanFilterValidator(gridTypeModel))
                .When(t => t.Type == GridFilterType.Boolean);

            RuleFor(p => p)
                .SetValidator(new DateFilterValidator(gridTypeModel))
                .When(t => t.Type == GridFilterType.Date);

            RuleFor(p => p)
                .SetValidator(new ListFilterValidator(gridTypeModel))
                .When(t => t.Type == GridFilterType.List);

            RuleFor(p => p)
                .SetValidator(new NumberFilterValidator(gridTypeModel))
                .When(t => t.Type == GridFilterType.Number);

            RuleFor(p => p)
                .SetValidator(new TextFilterValidator(gridTypeModel))
                .When(t => t.Type == GridFilterType.Text);
        }

        private static bool IsFilteringAllowed(GridTypeModel gridTypeModel, string propertyName)
        {
            return gridTypeModel.FilterablePropertyNames.Contains(propertyName);
        }
    }
}