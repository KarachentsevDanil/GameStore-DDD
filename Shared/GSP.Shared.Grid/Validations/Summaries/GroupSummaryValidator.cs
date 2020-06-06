using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Models.Summaries;
using GSP.Shared.Grid.Stores.Models;

namespace GSP.Shared.Grid.Validations.Summaries
{
    public class GroupSummaryValidator : AbstractValidator<GroupSummaryModel>
    {
        public GroupSummaryValidator(GridTypeModel gridTypeModel)
        {
            RuleFor(p => p.Type)
                .IsInEnum();

            RuleFor(p => p.PropertyName)
                .NotEmpty()
                .Must(p => IsGroupSummaryCalculationAllowed(gridTypeModel, p))
                .WithMessage($"Group summary calculation is not allowed for this property, you can use only {gridTypeModel.PropertyNames.ToStringList()} properties for grouping.");
        }

        private static bool IsGroupSummaryCalculationAllowed(GridTypeModel gridTypeModel, string propertyName)
        {
            return gridTypeModel.SummarizablePropertyNames.Contains(propertyName) && gridTypeModel.GroupablePropertyNames.Contains(propertyName);
        }
    }
}