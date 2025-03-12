namespace Project1.ProgramPart;

using Project1.Data.Models;
using Project1.ProgramPart;
using System.Text.RegularExpressions;

public static class ValidateService
{
    private static Regex loginRegex = new Regex(@"^(?=.*[A-Za-z0-9]$)[A-Za-z]([A-Za-z\d.-_]){0,19}$");
    private static Regex passwordRegex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%&_])[A-Za-z\d!@#$%&_]{8,16}$");
    
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
        return loginRegex.IsMatch(Email);
    }
}