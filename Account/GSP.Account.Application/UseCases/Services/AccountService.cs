using AutoMapper;
using GSP.Account.Application.UseCases.DTOs;
using GSP.Account.Application.UseCases.Exceptions;
using GSP.Account.Application.UseCases.Services.Contracts;
using GSP.Account.Domain.Entities;
using GSP.Account.Domain.UnitOfWorks.Contracts;
using GSP.Shared.Utils.Application.Configurations;
using GSP.Shared.Utils.Application.Helpers;
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
    public class AccountService : IAccountService
    {
        private readonly IAccountUnitOfWork _unitOfWork;

        private readonly ILogger _logger;

        private readonly IMapper _mapper;

        private readonly TokenConfiguration _configuration;

        public AccountService(
            IAccountUnitOfWork unitOfWork,
            ILogger<AccountService> logger,
            IMapper mapper,
            TokenConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<GetAccountDto> CreateAccountAsync(CreateAccountDto accountDto, CancellationToken ct = default)
        {
            _logger.LogInformation("Create account {@Account}", accountDto);

            AccountBase dbAccount = await _unitOfWork.AccountRepository.GetUserAsync(accountDto.Email, ct);

            if (dbAccount != null)
            {
                _logger.LogInformation("User with email {Email} already exists", dbAccount.Email);
                throw new AccountAlreadyExistException();
            }

            AccountBase account =
                new AccountBase(accountDto.FirstName, accountDto.LastName, accountDto.Email);

            account.SetPassword(accountDto.Password);

            _unitOfWork.AccountRepository.Create(account);

            await _unitOfWork.SaveAsync(ct);

            return _mapper.Map<GetAccountDto>(account);
        }

        public async Task<GetAccountDto> UpdateAccountAsync(UpdateAccountDto accountDto, CancellationToken ct = default)
        {
            _logger.LogInformation("Update account {@Account}", accountDto);

            AccountBase dbAccount = await _unitOfWork.AccountRepository.GetAsync(accountDto.Id, ct);

            if (dbAccount == null)
            {
                _logger.LogInformation("User with email {Id} doesn't exist", accountDto.Id);
                throw new AccountNotFoundException();
            }

            dbAccount.Update(accountDto.FirstName, accountDto.LastName);

            _unitOfWork.AccountRepository.Update(dbAccount);

            await _unitOfWork.SaveAsync(ct);

            return _mapper.Map<GetAccountDto>(dbAccount);
        }

        public async Task<GetAccountDto> GetAccountAsync(string email, CancellationToken ct = default)
        {
            _logger.LogInformation("Get account by email {Email}", email);

            AccountBase accountBase = await _unitOfWork.AccountRepository.GetUserAsync(email, ct);

            if (accountBase == null)
            {
                _logger.LogInformation("Account with email {Email} doesn't exist", email);
                throw new AccountNotFoundException();
            }

            return _mapper.Map<GetAccountDto>(accountBase);
        }

        public async Task<TokenDto> LoginAsync(LoginAccountDto accountDto, CancellationToken ct = default)
        {
            _logger.LogInformation("Login to account {@Account}", accountDto);

            AccountBase accountBase = await _unitOfWork.AccountRepository.GetUserAsync(accountDto.Email, ct);

            if (accountBase == null)
            {
                _logger.LogInformation("Account with email {Email} doesn't exist", accountDto.Email);
                throw new AccountNotFoundException();
            }

            if (!accountBase.IsPasswordEqual(accountDto.Password))
            {
                _logger.LogInformation("Password for email {Email} is wrong", accountDto.Email);
                throw new WrongPasswordException();
            }

            string token = TokenGeneratorHelper.GenerateToken(_configuration, GenerateClaims(accountBase));

            return new TokenDto(token, _configuration.ExpiresInDay);
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