using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Shared.Utils.Application.Account.UseCases.DTOs
{
    public class UpdateAccountDto : BaseUpdateItemDto
    {
        public UpdateAccountDto(long id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public UpdateAccountDto()
        {
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}