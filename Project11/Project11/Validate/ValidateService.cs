using System.Text.RegularExpressions;
using Data.User_DTO;

public static class ValidateService
{
    private static Regex loginRegex = new Regex(@"^(?=.*[A-Za-z0-9]$)[A-Za-z]([A-Za-z\d.-_]){0,19}$");
    private static Regex passwordRegex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%&_])[A-Za-z\d!@#$%&_]{8,16}$");
    
    public static bool ValidateLogin(Login_DTO loginDto)
    {
        return loginRegex.IsMatch(loginDto.username) && passwordRegex.IsMatch(loginDto.password);
    }
    
    public static bool ValidateRegister(Register_DTO registerDto)
    {
        return loginRegex.IsMatch(registerDto.username) && passwordRegex.IsMatch(registerDto.password);
    }
}