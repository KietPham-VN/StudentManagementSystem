namespace Application.Helpers;

public static class HashHelper
{
    public static string BCryptHash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool BCryptVerify(string inputPassword, string storedHash)
    {
        return BCrypt.Net.BCrypt.Verify(inputPassword, storedHash);
    }
}