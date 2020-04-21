using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Shared.Utils.Application.Account.UseCases.DTOs
{
    public class UpdateAccountDto : BaseUpdateItemDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}