using System.Security.Cryptography;
using System.Text;

namespace Application
{
    public static class PasswordManager
    {
        public static string GeneratePbkdf2Sha256PassDjango(this string? password, int saltLength = 12, int iterations = 260000)
        {
            // In Django, the default salt length for the PBKDF2 SHA256 password hashing algorithm is 12 bytes.
            string salt = saltLength.GeneratePassKey();

            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // The default number of iterations in the pbkdf2_sha256$ model for hashing passwords in Django is 260000 but you can upper this.
            using (var pbkdf2 = new Rfc2898DeriveBytes(passwordBytes, saltBytes, iterations, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(32); // 32 bytes for SHA-256
                string hashString = Convert.ToBase64String(hashBytes);
                string result = $"pbkdf2_sha256${iterations}${salt}${hashString}";
                return result;
            }
        }
        private static string GeneratePassKey(this int length)
        {
            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            var randNum = new Random();
            var chars = new char[length];
            for (var i = 0; i <= length - 1; i++)
            {
                chars[i] = allowedChars[Convert.ToInt32((allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
    }
}
