using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace GiftManagerWebApp.OtherClass
{
    public static class PasswordHash
    {

        public static bool CheckPasswordAndSalt(string password, string salt, string hashPassword)
        {
            string passWithSalt = password + salt;
            string hashToCheck = GenerateHashString(passWithSalt);


            if (hashPassword == hashToCheck)
            {
                return true;
            }
            return false;

        }
        public static void GenerateHashPassAndSalt(out string hashPass, out string salt, string inputPass)
        {

            salt = GenerateSalt(5, 10);
            string passWithSalt = inputPass + salt;
            hashPass = GenerateHashString(passWithSalt);

        }

        private static string GenerateHashString(string inputStrisng)
        {
            SHA256Managed sha256Managed = new SHA256Managed();

            byte[] outputByte = sha256Managed.ComputeHash(Encoding.UTF8.GetBytes(inputStrisng));

            return Convert.ToBase64String(outputByte);
        }

        private static string GenerateSalt(int minSaltSize, int maxSaltSize)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            Random random = new Random();

            int saltSize = random.Next(minSaltSize, maxSaltSize);

            byte[] saltByte = new byte[saltSize];

            rng.GetNonZeroBytes(saltByte);

            return Convert.ToBase64String(saltByte);
        }


    }
}