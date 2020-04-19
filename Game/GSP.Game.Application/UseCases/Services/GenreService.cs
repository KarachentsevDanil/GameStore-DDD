using AutoMapper;
using GSP.Game.Application.UseCases.DTOs.Genres;
using GSP.Game.Application.UseCases.Services.Contracts;
using GSP.Game.Domain.Entities;
using GSP.Game.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.Application.UseCases.Exceptions;
using GSP.Shared.Utils.Application.UseCases.Services;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Game.Application.UseCases.Services
{
    public class GenreService : BaseService<IGameUnitOfWork, Genre, GetGenreDto, AddGenreDto, UpdateGenreDto>, IGenreService
    {
        public GenreService(IGameUnitOfWork unitOfWork, IMapper mapper, ILogger<Genre> logger)
            : base(unitOfWork, unitOfWork.GenreRepository, mapper, logger)
        {
        }

        public async Task<GetGenreDto> GetByNameAsync(string name, CancellationToken ct = default)
        {
            Logger.LogInformation("Get genre by name = {Name}", name);

            Genre genre = await UnitOfWork.GenreRepository.GetByNameAsync(name, ct);

            if (genre == null)
            {
                Logger.LogInformation("Genre with {Name} doesn't exist", name);
                throw new ItemNotFoundException();
            }

            return Mapper.Map<GetGenreDto>(genre);
        }

        protected override Genre MapEntity(AddGenreDto addItemDto)
        {
            return new Genre(addItemDto.Name, addItemDto.Description);
        }

        protected override void UpdateEntity(UpdateGenreDto updateItemDto, Genre entity)
        {
            entity.Update(updateItemDto.Name, updateItemDto.Description);
        }
    }
}