using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Text;

namespace GSP.Shared.Utils.Common.Helpers
{
    public static class PasswordHasherHelper
    {
        private const int HashIteration = 10000;

        private const string Salt = "asfjio2j3423rd9s0fkds";

        private const int RequestedHashSize = 256 / 8;

        public static string HashPassword(string password)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.ASCII.GetBytes(Salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: HashIteration,
                numBytesRequested: RequestedHashSize));

            return hashed;
        }
    }
}