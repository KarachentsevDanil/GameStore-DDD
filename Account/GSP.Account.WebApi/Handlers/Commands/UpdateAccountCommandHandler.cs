using AutoMapper;
using GSP.Account.Application.DTOs;
using GSP.Account.Application.Services.Contracts;
using GSP.Account.WebApi.Commands;
using GSP.Shared.Utils.WebApi.Handlers.Abstracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Account.WebApi.Handlers.Commands
{
    public class UpdateAccountCommandHandler : BaseResponseHandler<UpdateAccountCommand, GetAccountDto>
    {
        private readonly IMapper _mapper;

        private readonly IAccountService _accountService;

        public UpdateAccountCommandHandler(IMapper mapper, IAccountService accountService, ILogger<UpdateAccountCommand> logger)
            : base(logger)
        {
            _mapper = mapper;
            _accountService = accountService;
        }

        protected override async Task<GetAccountDto> ExecuteAsync(UpdateAccountCommand request, CancellationToken ct)
        {
            UpdateAccountDto accountDto = _mapper.Map<UpdateAccountDto>(request);

            return await _accountService.UpdateAccountAsync(accountDto, ct);
        }
    }
}