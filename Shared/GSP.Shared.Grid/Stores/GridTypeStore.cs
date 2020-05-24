using GSP.Shared.Grid.Attributes;
using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Models;
using GSP.Shared.Grid.Stores.Contracts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GSP.Shared.Grid.Stores
{
    public class GridTypeStore : IGridTypeStore
    {
        private static readonly ConcurrentDictionary<string, GridTypeModel> GridTypes
            = new ConcurrentDictionary<string, GridTypeModel>();

        public GridTypeModel GetGridTypeModel(Type type)
        {
            var gridType = GridTypes.GetValueOrDefault(type.FullName);

            if (gridType == null)
            {
                gridType = GenerateGridType(type);
                GridTypes.TryAdd(type.FullName, gridType);
            }

            return gridType;
        }

        private static GridTypeModel GenerateGridType(Type type)
        {
            return new GridTypeModel(type, GetGridTypeProperties(type), GetIncludedEntities(type));
        }

        private static ICollection<string> GetIncludedEntities(Type type)
        {
            return type.GetProperties()
                .Where(p => p.PropertyType.IsClass && p.PropertyType.Assembly.FullName == type.Assembly.FullName)
                .Select(s => s.Name)
                .ToList();
        }

        private static ICollection<GridTypePropertyModel> GetGridTypeProperties(Type type)
        {
            var properties = type.GetProperties();
            var gridTypeProperties = new List<GridTypePropertyModel>();

            foreach (var property in properties)
            {
                AddGridTypeProperty(type, property, gridTypeProperties);
            }

            return gridTypeProperties;
        }

        private static void AddGridTypeProperty(Type type, PropertyInfo property, List<GridTypePropertyModel> gridTypeProperties)
        {
            if (!(property.PropertyType.IsClass &&
                  property.PropertyType.Assembly.FullName == type.Assembly.FullName))
            {
                var gridTypeProperty = new GridTypePropertyModel(property.Name, property.PropertyType)
                {
                    HasTotalCalculationSupport = property.PropertyType.IsNumericType()
                };

                ApplyGridPropertyAttributeIfExist(property, gridTypeProperty);
                gridTypeProperties.Add(gridTypeProperty);
            }
            else
            {
                HandleNavigationProperty(property, gridTypeProperties);
            }
        }

        private static void HandleNavigationProperty(PropertyInfo propertyInfo, ICollection<GridTypePropertyModel> propertyModels)
        {
            foreach (var property in propertyInfo.PropertyType.GetProperties())
            {
                var gridTypeProperty = new GridTypePropertyModel($"{propertyInfo.Name}.{property.Name}", property.PropertyType)
                {
                    HasTotalCalculationSupport = property.PropertyType.IsNumericType()
                };

                ApplyGridPropertyAttributeIfExist(property, gridTypeProperty);
                propertyModels.Add(gridTypeProperty);
            }
        }

        private static void ApplyGridPropertyAttributeIfExist(PropertyInfo propertyInfo, GridTypePropertyModel propertyModel)
        {
            GridPropertyAttribute gridParameterAttribute = propertyInfo.GetCustomAttribute<GridPropertyAttribute>();

            if (gridParameterAttribute == null)
            {
                return;
            }

            propertyModel.ApplyGridPropertyAttribute(gridParameterAttribute);
        }
    }
}