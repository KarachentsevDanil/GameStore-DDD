using AutoMapper;
using GSP.Rate.Application.UseCases.DTOs.Accounts;
using GSP.Rate.Application.UseCases.Services.Contracts;
using GSP.Rate.Domain.Entities;
using GSP.Rate.Domain.UnitOfWorks;
using GSP.Shared.Utils.Application.UseCases.Services;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace GSP.Rate.Application.UseCases.Services
{
    public class AccountService : BaseService<IRateUnitOfWork, Account, GetAccountDto, AddAccountDto, UpdateAccountDto>, IAccountService
    {
        public AccountService(IRateUnitOfWork unitOfWork, IBaseRepository<Account> repository, IMapper mapper, ILogger<Account> logger)
            : base(unitOfWork, repository, mapper, logger)
        {
        }

        protected override Account MapEntity(AddAccountDto addItemDto)
        {
            return new Account(addItemDto.Id, addItemDto.FirstName, addItemDto.LastName, addItemDto.Email);
        }

        protected override void UpdateEntity(UpdateAccountDto updateItemDto, Account entity)
        {
            entity.Update(updateItemDto.FirstName, updateItemDto.LastName, updateItemDto.Email);
        }
    }
}