using GSP.Account.Domain.Enums;

namespace GSP.Account.Application.UseCases.DTOs
{
    public class GetAccountDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public RoleType Role { get; set; }
    }
}