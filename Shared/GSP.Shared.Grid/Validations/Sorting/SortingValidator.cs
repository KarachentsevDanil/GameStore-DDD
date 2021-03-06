﻿using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Models.Sorting;
using GSP.Shared.Grid.Stores.Models;

namespace GSP.Shared.Grid.Validations.Sorting
{
    public class SortingValidator : AbstractValidator<SortingModel>
    {
        public SortingValidator(GridTypeModel gridTypeModel)
        {
            RuleFor(p => p.Direction)
                .IsInEnum();

            RuleFor(p => p.PropertyName)
                .NotEmpty()
                .Must(p => IsSortingAllowed(gridTypeModel, p))
                .WithMessage($"Sorting allowed only for {gridTypeModel.SortablePropertyNames.ToStringList()} properties.");
        }

        private static bool IsSortingAllowed(GridTypeModel gridTypeModel, string propertyName)
        {
            return gridTypeModel.SortablePropertyNames.Contains(propertyName);
        }
    }
}