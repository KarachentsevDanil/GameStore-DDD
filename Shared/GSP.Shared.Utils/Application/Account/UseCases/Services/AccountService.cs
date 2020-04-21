using AutoMapper;
using GSP.Shared.Utils.Application.Account.UseCases.DTOs;
using GSP.Shared.Utils.Application.Account.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.UseCases.Services;
using GSP.Shared.Utils.Domain.Account.Entities;
using GSP.Shared.Utils.Domain.Account.UnitOfWorks.Contracts;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace GSP.Shared.Utils.Application.Account.UseCases.Services
{
    public class AccountService<TUnitOfWork>
        : BaseService<TUnitOfWork, SharedAccount, GetAccountDto, AddAccountDto, UpdateAccountDto>, IAccountService
        where TUnitOfWork : IAccountUnitOfWork
    {
        public AccountService(
            TUnitOfWork unitOfWork,
            IBaseRepository<SharedAccount> repository,
            IMapper mapper,
            ILogger<SharedAccount> logger)
            : base(unitOfWork, repository, mapper, logger)
        {
        }

        protected override SharedAccount MapEntity(AddAccountDto addItemDto)
        {
            return new SharedAccount(addItemDto.Id, addItemDto.FirstName, addItemDto.LastName, addItemDto.Email);
        }

        protected override void UpdateEntity(UpdateAccountDto updateItemDto, SharedAccount entity)
        {
            entity.Update(updateItemDto.FirstName, updateItemDto.LastName, updateItemDto.Email);
        }
    }
}