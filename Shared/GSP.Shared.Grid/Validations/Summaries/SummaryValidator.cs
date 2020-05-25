using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Models;
using GSP.Shared.Grid.Summaries;

namespace GSP.Shared.Grid.Validations.Summaries
{
    public class SummaryValidator : AbstractValidator<SummaryModel>
    {
        public SummaryValidator(GridTypeModel gridTypeModel)
        {
            RuleFor(p => p.Type)
                .IsInEnum();

            RuleFor(p => p.PropertyName)
                .NotEmpty()
                .Must(p => IsSummaryCalculationAllowed(gridTypeModel, p))
                .WithMessage($"Summary calculation is not allowed for this property, you can use only {gridTypeModel.PropertyNames.ToStringList()} properties for grouping.");
        }

        private bool IsSummaryCalculationAllowed(GridTypeModel gridTypeModel, string propertyName)
        {
            return gridTypeModel.SummarizablePropertyNames.Contains(propertyName);
        }
    }
}