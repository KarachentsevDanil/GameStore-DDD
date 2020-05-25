using GSP.Shared.Grid.Columns.Contracts;
using GSP.Shared.Grid.Filters.Contracts;
using GSP.Shared.Grid.Grids.Contracts;
using GSP.Shared.Grid.Groups;
using GSP.Shared.Grid.Pagination.Models;
using GSP.Shared.Grid.Searching;
using GSP.Shared.Grid.Sorting;
using GSP.Shared.Grid.Summaries;
using System.Collections.Generic;
using System.Linq;

namespace GSP.Shared.Grid.Grids.Abstract
{
    public abstract class BaseGrid<TEntity, TGridColumn, TFilterType> : IGrid<TEntity, TGridColumn, TFilterType>
        where TFilterType : IFilter
        where TGridColumn : IGridColumn<TFilterType>
    {
        protected BaseGrid()
        {
            Groups = new List<GroupModel>();
            Summaries = new List<SummaryModel>();
            GroupSummaries = new List<GroupSummaryModel>();
            IncludeEntities = new List<string>();
        }

        public ICollection<TGridColumn> Columns { get; set; }

        public ICollection<GroupModel> Groups { get; set; }

        public ICollection<SummaryModel> Summaries { get; set; }

        public ICollection<GroupSummaryModel> GroupSummaries { get; set; }

        public SearchModel Search { get; set; }

        public PaginationModel Pagination { get; set; }

        public ICollection<string> IncludeEntities { get; set; }

        public virtual IList<SortingModel> GetSortingOptions()
        {
            return Columns
                .Where(q => q.Direction.HasValue)
                .OrderBy(o => o.Order)
                .Select(s => new SortingModel(s.PropertyName, s.Direction.Value))
                .ToList();
        }

        public virtual ICollection<string> GetGroupNames()
        {
            if (Groups == null)
            {
                return new List<string>();
            }

            return Groups.OrderBy(p => p.Order).Select(p => p.PropertyName).ToList();
        }
    }
}