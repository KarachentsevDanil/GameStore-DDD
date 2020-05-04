using AutoMapper;
using GSP.Shared.Utils.Application.UseCases.DTOs;
using GSP.Shared.Utils.Application.UseCases.Exceptions;
using GSP.Shared.Utils.Application.UseCases.Services.Contracts;
using GSP.Shared.Utils.Common.Extensions;
using GSP.Shared.Utils.Common.Models.Collections;
using GSP.Shared.Utils.Common.Models.FilterParams;
using GSP.Shared.Utils.Domain.Base;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using GSP.Shared.Utils.Domain.UnitOfWorks.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Application.UseCases.Services
{
    public abstract class BaseService<TUnitOfWork, TEntity, TGetItem, TAddItem, TUpdateItem>
        : IBaseService<TGetItem, TAddItem, TUpdateItem>
        where TGetItem : BaseGetItemDto
        where TAddItem : BaseAddItemDto
        where TUpdateItem : BaseUpdateItemDto
        where TEntity : BaseEntity
        where TUnitOfWork : IUnitOfWork
    {
        protected BaseService(TUnitOfWork unitOfWork, IBaseRepository<TEntity> repository, IMapper mapper, ILogger<TEntity> logger)
        {
            UnitOfWork = unitOfWork;
            EntityRepository = repository;
            Mapper = mapper;
            Logger = logger;
        }

        protected TUnitOfWork UnitOfWork { get; }

        protected IBaseRepository<TEntity> EntityRepository { get; }

        protected ILogger<TEntity> Logger { get; }

        protected IMapper Mapper { get; }

        public virtual async Task<TGetItem> AddAsync(TAddItem itemDto, CancellationToken ct = default)
        {
            Logger.LogInformation($"Create {nameof(TEntity)}, data = {itemDto.ToJsonString()}");

            await ValidateItemAsync(itemDto, ct);

            TEntity entity = MapEntity(itemDto);

            EntityRepository.Create(entity);

            await UnitOfWork.SaveAsync(ct);

            return Mapper.Map<TGetItem>(entity);
        }

        public virtual async Task<TGetItem> UpdateAsync(TUpdateItem itemDto, CancellationToken ct = default)
        {
            Logger.LogInformation($"Update {nameof(TEntity)}, data = {itemDto.ToJsonString()}");

            TEntity dbEntity = await EntityRepository.GetAsync(itemDto.Id, ct);

            if (dbEntity == null)
            {
                Logger.LogInformation($"{nameof(TEntity)} with id {itemDto.Id} doesn't exist");
                throw new ItemNotFoundException();
            }

            await ValidateItemAsync(dbEntity, itemDto, ct);

            UpdateEntity(itemDto, dbEntity);

            EntityRepository.Update(dbEntity);

            await UnitOfWork.SaveAsync(ct);

            return Mapper.Map<TGetItem>(dbEntity);
        }

        public virtual async Task<TGetItem> GetByIdAsync(long id, CancellationToken ct = default)
        {
            Logger.LogInformation($"Get {nameof(TEntity)} by id {id}");

            TEntity dbEntity = await EntityRepository.GetAsync(id, ct);

            if (dbEntity == null)
            {
                Logger.LogInformation($"{nameof(TEntity)} with id {id} doesn't exist");
                throw new ItemNotFoundException();
            }

            return Mapper.Map<TGetItem>(dbEntity);
        }

        public virtual async Task<IImmutableList<TGetItem>> GetAllAsync(CancellationToken ct = default)
        {
            Logger.LogInformation($"Get {nameof(TEntity)} list");

            ICollection<TEntity> dbEntities = await EntityRepository.GetListAsync(ct);

            return Mapper.Map<ICollection<TGetItem>>(dbEntities).ToImmutableList();
        }

        public virtual async Task<PagedCollection<TGetItem>> GetPagedListAsync(PaginationFilterParams filterParams, CancellationToken ct = default)
        {
            Logger.LogInformation($"Get {nameof(TEntity)} paged list with parameters {filterParams.ToJsonString()}");

            PagedCollection<TEntity> dbEntities = await EntityRepository.GetPagedListAsync(filterParams, ct);

            IImmutableList<TGetItem> itemsDto = Mapper.Map<ICollection<TGetItem>>(dbEntities.Items).ToImmutableList();

            return new PagedCollection<TGetItem>(itemsDto, dbEntities.TotalCount);
        }

        public async Task<bool> IsExistAsync(long id, CancellationToken ct = default)
        {
            Logger.LogInformation($"Is {nameof(TEntity)} with Id {id} exists.");
            return await EntityRepository.IsExistsAsync(id, ct);
        }

        protected abstract TEntity MapEntity(TAddItem addItemDto);

        protected abstract void UpdateEntity(TUpdateItem updateItemDto, TEntity entity);

        protected virtual Task ValidateItemAsync(TAddItem addItemDto, CancellationToken ct)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ValidateItemAsync(TEntity entity, TUpdateItem updateItemDto, CancellationToken ct)
        {
            return Task.CompletedTask;
        }
    }
}