﻿using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Models.Summaries;
using GSP.Shared.Grid.Stores.Models;

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

        private static bool IsSummaryCalculationAllowed(GridTypeModel gridTypeModel, string propertyName)
        {
            return gridTypeModel.SummarizablePropertyNames.Contains(propertyName);
        }
    }
}