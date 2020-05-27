using GSP.Shared.Grid.Filters;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Grid.Grids.Extensions.Search;
using GSP.Shared.Grid.Helpers;
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

        public ICollection<Filter<TEntity>> Filters { get; set; }

        public ICollection<SortingModel> SortingOptions { get; set; }

        public ICollection<GroupModel> Groups { get; set; }

        public ICollection<SummaryModel> Summaries { get; set; }

        public ICollection<GroupSummaryModel> GroupSummaries { get; set; }

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

        public Expression<Func<TEntity, bool>> GetFiltersExpression()
        {
            var expression = PredicateHelper.True<TEntity>();

            var customFilterExpression = GetCustomFilterExpression();
            if (customFilterExpression != null)
            {
                expression = expression.And(customFilterExpression);
            }

            var searchExpression = this.GetSearchExpression();
            if (searchExpression != null)
            {
                expression = expression.And(searchExpression);
            }

            foreach (var filter in Filters.Where(q => q.HasSelectedData))
            {
                var filterExpression = filter.GetExpression();
                if (filterExpression != null)
                {
                    expression = expression.And(filterExpression);
                }
            }

            return expression;
        }

        protected Expression<Func<TEntity, bool>> GetCustomFilterExpression()
        {
            return default;
        }
    }
}