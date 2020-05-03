using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Shared.Utils.Application.Account.UseCases.DTOs
{
    public class AddAccountDto : BaseAddItemDto
    {
        public AddAccountDto(long id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public AddAccountDto()
        {
        }

        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}