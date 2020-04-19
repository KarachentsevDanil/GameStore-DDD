using AutoMapper;
using GSP.Account.Application.UseCases.DTOs;
using GSP.Account.Application.UseCases.Exceptions;
using GSP.Account.Application.UseCases.Services.Contracts;
using GSP.Account.Domain.Entities;
using GSP.Account.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.Application.Configurations;
using GSP.Shared.Utils.Application.Helpers;
using GSP.Shared.Utils.Application.UseCases.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Account.Application.UseCases.Services
{
    public class AccountService :
        BaseService<IAccountUnitOfWork, AccountBase, GetAccountDto, CreateAccountDto, UpdateAccountDto>, IAccountService
    {
        private readonly TokenConfiguration _configuration;

        public AccountService(
            IAccountUnitOfWork unitOfWork,
            ILogger<AccountBase> logger,
            IMapper mapper,
            TokenConfiguration configuration)
            : base(unitOfWork, unitOfWork.AccountRepository, mapper, logger)
        {
            _configuration = configuration;
        }

        public async Task<GetAccountDto> GetAccountAsync(string email, CancellationToken ct = default)
        {
            Logger.LogInformation("Get account by email {Email}", email);

            AccountBase accountBase = await UnitOfWork.AccountRepository.GetUserAsync(email, ct);

            if (accountBase == null)
            {
                Logger.LogInformation("Account with email {Email} doesn't exist", email);
                throw new AccountNotFoundException();
            }

            return Mapper.Map<GetAccountDto>(accountBase);
        }

        public async Task<TokenDto> LoginAsync(LoginAccountDto accountDto, CancellationToken ct = default)
        {
            Logger.LogInformation("Login to account {@Account}", accountDto);

            AccountBase accountBase = await UnitOfWork.AccountRepository.GetUserAsync(accountDto.Email, ct);

            if (accountBase == null)
            {
                Logger.LogInformation("Account with email {Email} doesn't exist", accountDto.Email);
                throw new AccountNotFoundException();
            }

            if (!accountBase.IsPasswordEqual(accountDto.Password))
            {
                Logger.LogInformation("Password for email {Email} is wrong", accountDto.Email);
                throw new WrongPasswordException();
            }

            string token = TokenGeneratorHelper.GenerateToken(_configuration, GenerateClaims(accountBase));

            return new TokenDto(token, _configuration.ExpiresInDay);
        }

        protected override async Task ValidateItemAsync(CreateAccountDto addItemDto, CancellationToken ct)
        {
            AccountBase dbAccount = await UnitOfWork.AccountRepository.GetUserAsync(addItemDto.Email, ct);

            if (dbAccount != null)
            {
                Logger.LogInformation("User with email {Email} already exists", dbAccount.Email);
                throw new AccountAlreadyExistException();
            }
        }

        protected override AccountBase MapEntity(CreateAccountDto accountDto)
        {
            AccountBase account =
                new AccountBase(accountDto.FirstName, accountDto.LastName, accountDto.Email);

            account.SetPassword(accountDto.Password);

            return account;
        }

        protected override void UpdateEntity(UpdateAccountDto updateItemDto, AccountBase entity)
        {
            entity.Update(updateItemDto.FirstName, updateItemDto.LastName);
        }

        private IEnumerable<Claim> GenerateClaims(AccountBase accountBase)
        {
            var claims = new List<Claim>
            {
                new Claim(nameof(accountBase.Id), accountBase.Id.ToString(CultureInfo.InvariantCulture)),
                new Claim(nameof(accountBase.Email), accountBase.Email),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture)),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(_configuration.ExpiresInDay)).ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture))
            };

            return claims;
        }
    }
}