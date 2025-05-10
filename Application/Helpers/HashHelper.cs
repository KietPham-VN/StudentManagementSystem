namespace Application.Helpers
{
    public static class HashHelper
    {
        public static string BCriptHash(string input)
        {
            return BCrypt.Net.BCrypt.HashPassword(input);
        }

        public static bool BCriptVerify(string input, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(input, hash);
        }
    }
}