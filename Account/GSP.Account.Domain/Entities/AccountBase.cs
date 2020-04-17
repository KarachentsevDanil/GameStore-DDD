using GSP.Account.Domain.Enums;
using GSP.Account.Domain.Events;
using GSP.Shared.Utils.Common.Helpers;
using GSP.Shared.Utils.Domain.Base;

namespace GSP.Account.Domain.Entities
{
    public class AccountBase : BaseEntity
    {
        public AccountBase(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        /// <summary>
        /// Only for EF
        /// </summary>
        private AccountBase()
        {
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string HashedPassword { get; private set; }

        public RoleType Role { get; set; }

        public void SetPassword(string password)
        {
            HashedPassword = PasswordHasherHelper.HashPassword(password);
        }

        public bool IsPasswordEqual(string password)
        {
            return PasswordHasherHelper.HashPassword(password) == HashedPassword;
        }

        public void Update(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AccountUpdatedEvent updatedEvent = new AccountUpdatedEvent(Id, FirstName, LastName);

            DomainEvents.Add(updatedEvent);
        }
    }
}