using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using GSP.Shared.Utils.Application.Account.CQS.Commands;
using GSP.Shared.Utils.Application.Account.UseCases.DTOs;
using GSP.Shared.Utils.Application.Account.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;

namespace GSP.Shared.Utils.Application.Account.CQS.Handlers
{
    public class CreateAccountCommonHandler : BaseResponseHandler<CreateAccountCommand, GetAccountDto>
    {
        private readonly IMapper _mapper;

        private readonly IAccountService _accountService;

        public CreateAccountCommonHandler(
            ILogger<CreateAccountCommand> logger,
            IMapper mapper,
            IAccountService accountService)
            : base(logger)
        {
            _mapper = mapper;
            _accountService = accountService;
        }

        protected override async Task<GetAccountDto> ExecuteAsync(CreateAccountCommand request, CancellationToken ct)
        {
            AddAccountDto accountDto = _mapper.Map<AddAccountDto>(request);
            return await _accountService.AddAsync(accountDto, ct);
        }
    }
}