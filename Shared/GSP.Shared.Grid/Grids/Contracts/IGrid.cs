﻿using GSP.Shared.Grid.Columns.Contracts;
using GSP.Shared.Grid.Pagination.Models;
using GSP.Shared.Grid.Sorting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GSP.Shared.Grid.Grids.Contracts
{
    public interface IGrid<TEntity>
    {
        ICollection<IGridColumn<TEntity>> Columns { get; set; }

        PaginationModel Pagination { get; set; }

        Expression<Func<TEntity, bool>> GetGridFilterExpression();

        ICollection<SortingModel> GetSortingOptions();
    }
}