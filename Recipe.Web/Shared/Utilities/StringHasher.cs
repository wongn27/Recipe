using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Recipe.Web.Data.Utilities
{
    public static class StringHasher
    {

        public static string Hash(string value)
        {
            var hasher = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(value);
            var hashedBytes = hasher.ComputeHash(bytes);
            var hashedString = Encoding.UTF8.GetString(hashedBytes);
            return hashedString;
        }
    }
}
