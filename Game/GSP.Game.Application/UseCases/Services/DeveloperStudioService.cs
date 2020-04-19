using AutoMapper;
using GSP.Game.Application.UseCases.DTOs.DeveloperStudios;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Game.Domain.Entities;
using GSP.Game.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.Application.UseCases.Services;
using Microsoft.Extensions.Logging;

namespace GSP.Game.Application.UseCases.Services
{
    public class DeveloperStudioService
        : BaseService<IGameUnitOfWork, DeveloperStudio, GetDeveloperStudioDto, AddDeveloperStudioDto, UpdateDeveloperStudioDto>, IDeveloperStudioService
    {
        public DeveloperStudioService(IGameUnitOfWork unitOfWork, IMapper mapper, ILogger<DeveloperStudio> logger)
            : base(unitOfWork, unitOfWork.DeveloperStudioRepository, mapper, logger)
        {
        }

        protected override DeveloperStudio MapEntity(AddDeveloperStudioDto addItemDto)
        {
            return new DeveloperStudio(addItemDto.Name, addItemDto.Description, addItemDto.LogoUri, addItemDto.WebPageUri);
        }

        protected override void UpdateEntity(UpdateDeveloperStudioDto updateItemDto, DeveloperStudio entity)
        {
            entity.Update(updateItemDto.Name, updateItemDto.Description, updateItemDto.LogoUri, updateItemDto.WebPageUri);
        }
    }
}