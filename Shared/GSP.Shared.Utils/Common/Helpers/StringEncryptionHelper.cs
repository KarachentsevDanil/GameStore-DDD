using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GSP.Shared.Utils.Common.Helpers
{
    public static class StringEncryptionHelper
    {
        private const string Key = "GSP.MyAppPrivateKey";

        private static readonly byte[] Salt = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };

        public static string Encrypt(string clearText, string encryptionKey = Key)
        {
            byte[] unencryptedBytes = Encoding.Unicode.GetBytes(clearText);

            using (var encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, Salt);

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(unencryptedBytes, 0, unencryptedBytes.Length);
                        cryptoStream.Close();
                    }

                    clearText = Convert.ToBase64String(memoryStream.ToArray());
                }
            }

            return clearText;
        }

        public static string Decrypt(string text, string encryptionKey = Key)
        {
            text = text.Replace(" ", "+", StringComparison.InvariantCultureIgnoreCase);

            byte[] cryptedBytes = Convert.FromBase64String(text);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, Salt);

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(cryptedBytes, 0, cryptedBytes.Length);
                        cryptoStream.Close();
                    }

                    text = Encoding.Unicode.GetString(memoryStream.ToArray());
                }
            }

            return text;
        }
    }
}