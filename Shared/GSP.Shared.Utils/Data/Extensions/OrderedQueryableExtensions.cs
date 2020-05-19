using GSP.Shared.Grid.Sorting;
using GSP.Shared.Grid.Sorting.Enums;
using System.Collections.Generic;
using System.Linq;

namespace GSP.Shared.Utils.Data.Extensions
{
    public static class OrderedQueryableExtensions
    {
        public static IQueryable<TEntity> Ordered<TEntity>(this IQueryable<TEntity> sequence, IList<SortingModel> orderByList)
        {
            if (orderByList.Any())
            {
                return sequence;
            }

            var firstSortingModel = orderByList.First();

            IOrderedQueryable<TEntity> orderedQuery = firstSortingModel.Direction == SortingDirection.Ascending
                ? sequence.OrderByDynamic(firstSortingModel.ToString())
                : sequence.OrderByDescendingDynamic(firstSortingModel.ToString());

            for (var i = 1; i < orderByList.Count; i++)
            {
                var orderArgument = orderByList[i];

                orderedQuery = orderArgument.Direction == SortingDirection.Ascending
                    ? orderedQuery.ThenByDynamic(firstSortingModel.ToString())
                    : orderedQuery.ThenByDescendingDynamic(firstSortingModel.ToString());
            }

            return orderedQuery;
        }
    }
}