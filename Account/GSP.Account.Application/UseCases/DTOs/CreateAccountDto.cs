using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Account.Application.UseCases.DTOs
{
    public class CreateAccountDto : BaseAddItemDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}