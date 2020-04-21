using GSP.Shared.Utils.Application.Account.UseCases.DTOs;
using GSP.Shared.Utils.Application.UseCases.Services.Contracts;

namespace GSP.Shared.Utils.Application.Account.UseCases.Services.Contracts
{
    public interface IAccountService : IBaseService<GetAccountDto, AddAccountDto, UpdateAccountDto>
    {
    }
}