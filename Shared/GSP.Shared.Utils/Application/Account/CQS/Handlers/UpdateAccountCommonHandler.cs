using AutoMapper;
using FluentValidation;
using GSP.Shared.Utils.Application.Account.CQS.Commands;
using GSP.Shared.Utils.Application.Account.UseCases.DTOs;
using GSP.Shared.Utils.Application.Account.UseCases.Services.Contracts;
using GSP.Shared.Utils.Application.CQS.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Application.Account.CQS.Handlers
{
    public class UpdateAccountCommonHandler : BaseResponseHandler<UpdateAccountCommand, GetAccountDto>
    {
        private readonly IMapper _mapper;

        private readonly IAccountService _accountService;

        public UpdateAccountCommonHandler(
            ILogger<UpdateAccountCommand> logger,
            IMapper mapper,
            IAccountService accountService)
            : base(logger)
        {
            _mapper = mapper;
            _accountService = accountService;
        }

        protected override async Task<GetAccountDto> ExecuteAsync(UpdateAccountCommand request, CancellationToken ct)
        {
            UpdateAccountDto accountDto = _mapper.Map<UpdateAccountDto>(request);
            return await _accountService.UpdateAsync(accountDto, ct);
        }
    }
}