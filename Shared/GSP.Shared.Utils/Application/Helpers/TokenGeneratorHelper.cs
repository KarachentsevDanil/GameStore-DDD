using GSP.Shared.Utils.Application.Configurations;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GSP.Shared.Utils.Application.Helpers
{
    public static class TokenGeneratorHelper
    {
        public static string GenerateToken(TokenConfiguration tokenConfiguration, IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenConfiguration.Secret));

            JwtSecurityToken token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(key, SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}