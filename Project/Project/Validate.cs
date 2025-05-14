using System.Text.RegularExpressions;

using Project.Models;

namespace Project;
public static class ValidateService
{
    private static Regex loginRegex = new Regex(@"^(?=.*[A-Za-z0-9]$)[A-Za-z]([A-Za-z\d.-_]){0,19}$");
    private static Regex passwordRegex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%&_])[A-Za-z\d!@#$%&_]{8,16}$");
    private static Regex emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    public static bool ValidateLogin(string Login, string Password)
    {
        return loginRegex.IsMatch(Login) && passwordRegex.IsMatch(Password);
    }
    
    public static bool ValidateRegister(User user)
    {
        return loginRegex.IsMatch(user.Login) && passwordRegex.IsMatch(user.Password);
    }
    
    public static bool ValidateEmail(string Email)
    {
        return emailRegex.IsMatch(Email);
    }
}