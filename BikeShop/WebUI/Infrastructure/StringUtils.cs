using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace WebUI.Infrastructure
{
    public static class StringUtils
    {
        private static string GetRandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random(DateTime.Now.Millisecond);
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        private static string getHashedPassword(string password, string salt)
        {
            string result;
            using (HashAlgorithm hash = new SHA256CryptoServiceProvider())
            {
                byte[] passwithsalt = Encoding.UTF8.GetBytes(password + salt);
                result = Convert.ToBase64String(hash.ComputeHash(passwithsalt));
            }
            return result;
        }

        public static IDictionary<string, string> getSaltHash(string password)
        {
            var result = new Dictionary<string, string>();
            var rnd = GetRandomString(5);
            byte[] saltBytes = Encoding.UTF8.GetBytes(rnd);
            string salt = Convert.ToBase64String(saltBytes);
            result.Add("salt", salt );
            result.Add("hash", getHashedPassword(password,salt));
            return result;
        }

        public static bool IsValidPassword(string password, string salt, string hash)
        {
            return getHashedPassword(password, salt) == hash;
        }

    }
}