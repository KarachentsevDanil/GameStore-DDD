﻿namespace GSP.Account.WebApi.Bus.Messages
{
    public abstract class BaseAccountMessage
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}