using GSP.Shared.Grid.Extensions;
using GSP.Shared.Grid.Filters;
using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Grid.Models.Groups;
using GSP.Shared.Grid.Models.Pagination;
using GSP.Shared.Grid.Models.Searching;
using GSP.Shared.Grid.Models.Sorting;
using GSP.Shared.Grid.Models.Summaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Grids
{
    public abstract class BaseGrid<TEntity> : IGrid<TEntity>
    {
        protected BaseGrid()
        {
            Groups = new List<GroupModel>();
            Summaries = new List<SummaryModel>();
            GroupSummaries = new List<GroupSummaryModel>();
            IncludeEntities = new List<string>();
            SortingOptions = new List<SortingModel>();
            Filters = new List<Filter<TEntity>>();
        }

        public List<Filter<TEntity>> Filters { get; set; }

        public List<SortingModel> SortingOptions { get; set; }

        public List<GroupModel> Groups { get; set; }

        public List<SummaryModel> Summaries { get; set; }

        public List<GroupSummaryModel> GroupSummaries { get; set; }

        public SearchModel Search { get; set; }

        public PaginationModel Pagination { get; set; }

        public ICollection<string> IncludeEntities { get; set; }

        public virtual IList<SortingModel> GetSortedSortingOptions()
        {
            return SortingOptions
                .OrderBy(o => o.Order)
                .ToList();
        }

        public virtual ICollection<string> GetGroupNames()
        {
            return Groups.OrderBy(p => p.Order).Select(p => p.PropertyName).ToList();
        }

        public virtual ICollection<string> GetIncludedEntities()
        {
            Groups.ForEach(g => AddNavigationPropertyIfNeeded(g.PropertyName));
            GroupSummaries.ForEach(g => AddNavigationPropertyIfNeeded(g.PropertyName));
            Filters.ForEach(g => AddNavigationPropertyIfNeeded(g.PropertyName));
            SortingOptions.ForEach(g => AddNavigationPropertyIfNeeded(g.PropertyName));
            Summaries.ForEach(g => AddNavigationPropertyIfNeeded(g.PropertyName));

            return IncludeEntities;
        }

        public virtual Expression<Func<TEntity, bool>> GetCustomFilterExpression()
        {
            return default;
        }

        private void AddNavigationPropertyIfNeeded(string propertyName)
        {
            if (propertyName.IsNavigationProperty())
            {
                var navigationPropertyName = propertyName.GetNavigationProperty();
                if (!IncludeEntities.Contains(navigationPropertyName))
                {
                    IncludeEntities.Add(navigationPropertyName);
                }
            }
        }
    }
}