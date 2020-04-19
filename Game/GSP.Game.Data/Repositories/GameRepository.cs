using GSP.Game.Data.Context;
using GSP.Game.Domain.Entities;
using GSP.Game.Domain.Enums;
using GSP.Game.Domain.Models.FilterParams;
using GSP.Game.Domain.Repositories.Contracts;
using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Shared.Utils.Data.Repositories;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Data.Repositories
{
    public class GameRepository : BaseRepository<GameDbContext, GameBase>, IGameRepository
    {
        public GameRepository(GameDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<GameBase>> GetByIdsAsync(IEnumerable<long> ids, CancellationToken ct)
        {
            return await Set.Where(t => ids.Contains(t.Id)).AsNoTracking().ToListAsync(ct);
        }

        public async Task<PagedCollection<GameBase>> GetByFilterParamsAsync(GameFilterParams filterParams, CancellationToken ct)
        {
            var query = GetGames();

            FillGamesQueryFilterParams(filterParams);
            query = FillSortParams(query, filterParams);

            int totalCount = query.Count();

            var games = await query
                .Skip(filterParams.PageSize * (filterParams.PageNumber - 1))
                .Take(filterParams.PageSize)
                .AsNoTracking()
                .ToListAsync(ct);

            PagedCollection<GameBase> result = new PagedCollection<GameBase>(games.ToImmutableList(), totalCount);

            return result;
        }

        private void FillGamesQueryFilterParams(GameFilterParams filterParams)
        {
            var predicate = PredicateBuilder.New<GameBase>(x => !x.IsDeleted);

            if (filterParams.GenreIds != null && filterParams.GenreIds.Any())
            {
                predicate = predicate.Extend(p => filterParams.GenreIds.Contains(p.GenreId), PredicateOperator.And);
            }

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                predicate = predicate.Extend(
                    x => EF.Functions.Like(x.GameDetails.Name, filterParams.Term), PredicateOperator.And);
            }

            if (filterParams.StartPrice.HasValue && filterParams.EndPrice.HasValue)
            {
                predicate = predicate.Extend(
                    x => filterParams.StartPrice <= x.GameDetails.Price &&
                         filterParams.EndPrice >= x.GameDetails.Price, PredicateOperator.And);
            }

            filterParams.Expression = predicate;
        }

        private IQueryable<GameBase> FillSortParams(IQueryable<GameBase> query, GameFilterParams filterParams)
        {
            query = query.Where(filterParams.Expression);

            switch (filterParams.SortMode)
            {
                case GameSortMode.ByName:
                    query = query.OrderBy(x => x.GameDetails.Name).AsQueryable();
                    break;
                case GameSortMode.ByCountOfSales:
                    query = query.OrderByDescending(x => x.GameDetails.OrderCount).AsQueryable();
                    break;
                case GameSortMode.ByRating:
                    query = query.OrderByDescending(x => x.GameDetails.AverageRating).AsQueryable();
                    break;
                case GameSortMode.ByPriceHighToLow:
                    query = query.OrderByDescending(x => x.GameDetails.Price).AsQueryable();
                    break;
                case GameSortMode.ByPriceLowToHigh:
                    query = query.OrderBy(x => x.GameDetails.Price).AsQueryable();
                    break;
            }

            return query;
        }

        private IQueryable<GameBase> GetGames()
        {
            return Set
                .Include(x => x.GameDetails)
                .Include(x => x.Genre)
                .Include(x => x.DeveloperStudio)
                .Include(x => x.Publisher)
                .Include(x => x.Attachments)
                .AsQueryable();
        }
    }
}