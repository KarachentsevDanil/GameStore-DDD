using GSP.Game.Application.UseCases.DTOs.Publishers;
using GSP.Shared.Utils.Application.UseCases.Services.Contracts;

namespace GSP.Game.Application.UseCases.Services.Contracts
{
    public interface IPublisherService : IBaseService<GetPublisherDto, AddPublisherDto, UpdatePublisherDto>
    {
    }
}