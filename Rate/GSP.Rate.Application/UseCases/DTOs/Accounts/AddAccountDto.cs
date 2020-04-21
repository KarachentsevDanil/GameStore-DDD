using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Rate.Application.UseCases.DTOs.Accounts
{
    public class AddAccountDto : BaseAddItemDto
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}