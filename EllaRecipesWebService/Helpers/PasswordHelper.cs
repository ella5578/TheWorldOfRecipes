using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ServiceLibrary.Helpers
{
    public class PasswordHelper
    {
        public static bool IsPasswordStrong(string password)
        {
            if (string.IsNullOrWhiteSpace(password) ||
                password.Length < 8 ||
                !password.Any(char.IsUpper) ||
                !password.Any(char.IsLower) ||
                !password.Any(char.IsDigit) ||
                !password.Any(ch => "!@#$%^&*()_+-=[]{}|;:'\",.<>?/".Contains(ch)))
            {
                return false;
            }

            return true;
        }
        public static (string hash, string salt) HashPassword(string password)
        {
            byte[] saltBytes = new byte[16];
            RandomNumberGenerator.Fill(saltBytes); 

            string salt = Convert.ToBase64String(saltBytes);
            string hash = ComputeHash(password, salt);

            return (hash, salt);
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            string hashToVerify = ComputeHash(enteredPassword, storedSalt);
            return hashToVerify == storedHash;
        }

        private static string ComputeHash(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] saltedPassword = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha256.ComputeHash(saltedPassword);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
