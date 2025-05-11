using System.Security.Cryptography;

namespace Application.Helpers
{
    public static class HashHelper
    {
        public static string GenerateSalt(int length = 16)
        {
            var saltBytes = new byte[length];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        public static string BCryptHash(string password, string salt)
        {
            // Gắn salt thủ công vào trước khi hash
            string saltedPassword = salt + password;
            return BCrypt.Net.BCrypt.HashPassword(saltedPassword);
        }

        public static bool BCryptVerify(string inputPassword, string storedHash, string storedSalt)
        {
            string saltedInput = storedSalt + inputPassword;
            return BCrypt.Net.BCrypt.Verify(saltedInput, storedHash);
        }
    }
}