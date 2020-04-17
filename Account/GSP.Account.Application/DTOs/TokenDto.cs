﻿namespace GSP.Account.Application.DTOs
{
    public class TokenDto
    {
        public TokenDto(string token, int tokenLifetime)
        {
            Token = token;
            TokenLifetime = tokenLifetime;
        }

        public string Token { get; set; }

        public int TokenLifetime { get; set; }
    }
}