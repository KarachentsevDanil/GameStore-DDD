using GSP.Account.Domain.Enums;
using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Account.Application.UseCases.DTOs
{
    public class GetAccountDto : BaseGetItemDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public RoleType Role { get; set; }
    }
}