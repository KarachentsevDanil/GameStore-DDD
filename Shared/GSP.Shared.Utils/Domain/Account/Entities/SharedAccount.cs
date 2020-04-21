using GSP.Shared.Utils.Domain.Base;

namespace GSP.Shared.Utils.Domain.Account.Entities
{
    public class SharedAccount : BaseEntity
    {
        public SharedAccount(long id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        private SharedAccount()
        {
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public void Update(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}