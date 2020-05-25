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
    public abstract class BaseGrid<TEntity, TFilterType> : IGrid<TEntity, TFilterType>
        where TFilterType : IFilter
    {
        protected BaseGrid()
        {
            Groups = new List<GroupModel>();
            Summaries = new List<SummaryModel>();
            GroupSummaries = new List<GroupSummaryModel>();
            IncludeEntities = new List<string>();
            SortingOptions = new List<SortingModel>();
            Filters = new List<TFilterType>();
        }

        public ICollection<TFilterType> Filters { get; set; }

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
            if (Groups == null)
            {
                return new List<string>();
            }

            return Groups.OrderBy(p => p.Order).Select(p => p.PropertyName).ToList();
        }
    }
}