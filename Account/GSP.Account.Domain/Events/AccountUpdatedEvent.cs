using MediatR;

namespace GSP.Account.Domain.Events
{
    public class AccountUpdatedEvent : INotification
    {
        public AccountUpdatedEvent(long id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}