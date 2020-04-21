using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Rate.Application.UseCases.DTOs.Accounts
{
    public class GetAccountDto : BaseGetItemDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}