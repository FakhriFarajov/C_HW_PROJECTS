namespace Project.Utilities;

public static class PasswordHashing
{
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password,12);
    }

    public static bool VerifyHashedPassword(string hashedPassword, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}