using GSP.Rate.Application.UseCases.DTOs.Accounts;
using GSP.Shared.Utils.Application.UseCases.Services.Contracts;

namespace GSP.Rate.Application.UseCases.Services.Contracts
{
    public interface IAccountService : IBaseService<GetAccountDto, AddAccountDto, UpdateAccountDto>
    {
    }
}