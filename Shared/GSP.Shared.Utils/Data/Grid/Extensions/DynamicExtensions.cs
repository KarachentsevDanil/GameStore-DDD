﻿using GSP.Shared.Utils.Common.Helpers;
using GSP.Shared.Utils.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GSP.Shared.Utils.Data.Grid.Extensions
{
    public static class DynamicExtensions
    {
        private const string EntitySelector = "Entity";

        private const string EntityKeySelector = "Entity.Key";

        private const string PropertySeparator = ",";

        private const string CollectionSelector = "Items";

        private const string NavigationSeparator = ".";

        private const string GroupSeparator = "_";

        private const string GroupByExpressionFormat = "new {{ {0} }}";

        private const string SelectExpressionFormat = "{0} => new {{ {1}, Items = {0} }}";

        public static List<dynamic> GroupByDynamic<TEntity>(this List<TEntity> list, ICollection<string> groupByProperties)
        {
            var groupByField = string.Join(PropertySeparator, groupByProperties.Select(ProcessNavigationProperty));
            var selectGroupedFields = string.Join(PropertySeparator, groupByProperties.Select(ProcessNavigationPropertyInSelector));

            var groupByExpression = string.Format(CultureInfo.CurrentCulture, GroupByExpressionFormat, groupByField);
            var selectExpression = string.Format(CultureInfo.CurrentCulture, SelectExpressionFormat, EntitySelector, selectGroupedFields);

            return list.AsQueryable()
                .GroupByDynamic(groupByExpression)
                .SelectDynamic(selectExpression)
                .ToDynamicList();
        }

        public static ICollection<TEntity> GetCollection<TEntity>(object groupedItem)
        {
            return ObjectHelper.GetPropertyValue(groupedItem, CollectionSelector) as ICollection<TEntity>;
        }

        public static string GetGroupKey(object groupedItem, IEnumerable<string> groupedProperties)
        {
            return string.Join(
                GroupSeparator,
                groupedProperties.Select(p => ObjectHelper.GetPropertyValue(groupedItem, ProcessNavigationPropertyForGroupKey(p))));
        }

        private static string ProcessNavigationProperty(string propertyName)
        {
            return propertyName.Contains(NavigationSeparator, StringComparison.InvariantCultureIgnoreCase) ?
                $"{propertyName} as {propertyName.Replace(NavigationSeparator, string.Empty, StringComparison.InvariantCultureIgnoreCase)}" :
                propertyName;
        }

        private static string ProcessNavigationPropertyInSelector(string propertyName)
        {
            return propertyName.Contains(NavigationSeparator, StringComparison.InvariantCultureIgnoreCase) ?
                $"{EntityKeySelector}.{propertyName.Replace(NavigationSeparator, string.Empty, StringComparison.InvariantCultureIgnoreCase)}" :
                $"{EntityKeySelector}.{propertyName}";
        }

        private static string ProcessNavigationPropertyForGroupKey(string propertyName)
        {
            return propertyName.Contains(NavigationSeparator, StringComparison.InvariantCultureIgnoreCase) ?
                propertyName.Replace(NavigationSeparator, string.Empty, StringComparison.InvariantCultureIgnoreCase) :
                propertyName;
        }
    }
}