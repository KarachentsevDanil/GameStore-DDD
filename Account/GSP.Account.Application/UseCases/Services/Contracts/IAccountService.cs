using GSP.Account.Application.UseCases.DTOs;
using GSP.Shared.Utils.Application.UseCases.Services.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Account.Application.UseCases.Services.Contracts
{
    public interface IAccountService : IBaseService<GetAccountDto, CreateAccountDto, UpdateAccountDto>
    {
        Task<GetAccountDto> GetAccountAsync(string email, CancellationToken ct = default);

        Task<TokenDto> LoginAsync(LoginAccountDto accountDto, CancellationToken ct = default);
    }
}