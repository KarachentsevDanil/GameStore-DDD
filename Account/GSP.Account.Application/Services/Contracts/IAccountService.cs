﻿using System.Threading;
using System.Threading.Tasks;
using GSP.Account.Application.DTOs;

namespace GSP.Account.Application.Services.Contracts
{
    public interface IAccountService
    {
        Task<GetAccountDto> CreateAccountAsync(CreateAccountDto accountDto, CancellationToken ct = default);

        Task<GetAccountDto> UpdateAccountAsync(UpdateAccountDto accountDto, CancellationToken ct = default);

        Task<GetAccountDto> GetAccountAsync(string email, CancellationToken ct = default);

        Task<TokenDto> LoginAsync(LoginAccountDto accountDto, CancellationToken ct = default);
    }
}