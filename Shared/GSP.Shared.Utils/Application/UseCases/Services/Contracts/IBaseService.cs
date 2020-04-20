using GSP.Shared.Utils.Application.UseCases.DTOs;
using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Shared.Utils.Common.Models.FilterParams;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Application.UseCases.Services.Contracts
{
    public interface IBaseService<TGetItem, TAddItem, TUpdateItem>
        where TGetItem : BaseGetItemDto
        where TAddItem : BaseAddItemDto
        where TUpdateItem : BaseUpdateItemDto
    {
        Task<TGetItem> AddAsync(TAddItem itemDto, CancellationToken ct = default);

        Task<TGetItem> UpdateAsync(TUpdateItem itemDto, CancellationToken ct = default);

        Task<TGetItem> GetByIdAsync(long id, CancellationToken ct = default);

        Task<IImmutableList<TGetItem>> GetAllAsync(CancellationToken ct = default);

        Task<PagedCollection<TGetItem>> GetPagedListAsync(PaginationFilterParams filterParams, CancellationToken ct = default);

        Task<bool> IsExistAsync(long id, CancellationToken ct = default);
    }
}