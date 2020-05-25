using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Models.Groups;
using GSP.Shared.Grid.Stores.Models;

namespace GSP.Shared.Grid.Validations.Groups
{
    public class GroupValidator : AbstractValidator<GroupModel>
    {
        public GroupValidator(GridTypeModel gridTypeModel)
        {
            RuleFor(p => p.PropertyName)
                .NotEmpty()
                .Must(p => IsGroupingAllowed(gridTypeModel, p))
                .WithMessage($"Grouping is not allowed for this property, you can use only {gridTypeModel.PropertyNames.ToStringList()} properties for grouping.");
        }

        private bool IsGroupingAllowed(GridTypeModel gridTypeModel, string propertyName)
        {
            return gridTypeModel.GroupablePropertyNames.Contains(propertyName);
        }
    }
}