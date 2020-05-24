﻿using FluentValidation;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Models;

namespace GSP.Shared.Grid.Validations.Filters
{
    public class BooleanFilterValidator<TFilter> : AbstractValidator<TFilter>
        where TFilter : IFilter
    {
        public BooleanFilterValidator(GridTypeModel gridTypeModel)
        {
            RuleFor(p => p.BooleanFilterOption)
                .NotNull()
                .IsInEnum();

            RuleFor(p => p)
                .Must(p => IsBooleanProperty(gridTypeModel, p.PropertyName))
                .WithMessage($"Only boolean properties are allowed for this type of filer {gridTypeModel.BooleanProperties.ToStringList()}.");
        }

        private bool IsBooleanProperty(GridTypeModel gridTypeModel, string propertyName)
        {
            return gridTypeModel.BooleanProperties.Contains(propertyName);
        }
    }
}