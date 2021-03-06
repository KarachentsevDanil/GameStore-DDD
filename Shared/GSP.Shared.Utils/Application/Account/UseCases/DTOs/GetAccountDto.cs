﻿using GSP.Shared.Utils.Application.UseCases.DTOs;

namespace GSP.Shared.Utils.Application.Account.UseCases.DTOs
{
    public class GetAccountDto : BaseGetItemDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}