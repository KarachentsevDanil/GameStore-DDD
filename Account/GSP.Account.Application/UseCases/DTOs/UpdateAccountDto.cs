using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Account.Application.UseCases.DTOs
{
    public class UpdateAccountDto : BaseUpdateItemDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}