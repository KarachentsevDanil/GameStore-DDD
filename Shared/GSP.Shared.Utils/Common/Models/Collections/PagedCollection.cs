﻿using System.Collections.Generic;
using System.Collections.Immutable;

namespace GSP.Shared.Utils.Common.Models.Collections
{
    public class PagedCollection<TEntity>
        where TEntity : class
    {
        public PagedCollection(IImmutableList<TEntity> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }

        public PagedCollection(IEnumerable<TEntity> items, int totalCount)
        {
            Items = items.ToImmutableList();
            TotalCount = totalCount;
        }

        public IImmutableList<TEntity> Items { get; private set; }

        public int TotalCount { get; private set; }
    }
}