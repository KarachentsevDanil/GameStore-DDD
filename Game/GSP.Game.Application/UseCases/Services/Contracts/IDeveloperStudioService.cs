using GSP.Game.Application.UseCases.DTOs.DeveloperStudios;
using GSP.Shared.Utils.Application.UseCases.Services.Contracts;

namespace GSP.Game.Application.UseCases.Services.Contracts
{
    public interface IDeveloperStudioService : IBaseService<GetDeveloperStudioDto, AddDeveloperStudioDto, UpdateDeveloperStudioDto>
    {
    }
}