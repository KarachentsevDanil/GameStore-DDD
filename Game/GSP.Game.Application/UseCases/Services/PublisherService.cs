using AutoMapper;
using GSP.Game.Application.UseCases.DTOs.Publishers;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Game.Domain.Entities;
using GSP.Game.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.Application.UseCases.Services;
using Microsoft.Extensions.Logging;

namespace GSP.Game.Application.UseCases.Services
{
    public class PublisherService
        : BaseService<IGameUnitOfWork, Publisher, GetPublisherDto, AddPublisherDto, UpdatePublisherDto>, IPublisherService
    {
        public PublisherService(IGameUnitOfWork unitOfWork, IMapper mapper, ILogger<Publisher> logger)
            : base(unitOfWork, unitOfWork.PublisherRepository, mapper, logger)
        {
        }

        protected override Publisher MapEntity(AddPublisherDto addItemDto)
        {
            return new Publisher(addItemDto.Name, addItemDto.Description, addItemDto.LogoUri, addItemDto.WebPageUri);
        }

        protected override void UpdateEntity(UpdatePublisherDto updateItemDto, Publisher entity)
        {
            entity.Update(updateItemDto.Name, updateItemDto.Description, updateItemDto.LogoUri, updateItemDto.WebPageUri);
        }
    }
}