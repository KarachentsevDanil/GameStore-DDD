using GSP.WepApi.Aggregator.DTOs.Games;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSP.WepApi.Aggregator.Services.Api.Contracts
{
    public interface IGameApiClient
    {
        [Get("/api/usergame/{id}")]
        Task<GetGameDto> GetGameByIdAsync(long id);

        [Post("/api/usergame/")]
        Task<ICollection<GetGameDto>> GetGameByIdsAsync([Body] GetGameByIdsDto ids);
    }
}