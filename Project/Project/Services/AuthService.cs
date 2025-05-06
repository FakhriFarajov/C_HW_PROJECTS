using Project.Models;

namespace Project.Services;

public class AuthService
{
    public User Login(string Login, string Password)
    {
        if (!ValidateService.ValidateLogin(Login, Password))//Validate the credentials
            throw new Exception("Invalid credentials!");
        
        using var context = new ContextMovie();
        var UsersList = context.Users.ToList();

        foreach (var user in UsersList)//If login and password are in list return user
        {
            if (user.Login == Login && BCrypt.Net.BCrypt.EnhancedVerify(Password, user.Password))
            {
                return user;
            }
        }
        throw new Exception("There is no such user!"); //else exception
    }


    public void Register(ref User UserToReg)
    {
        if (!ValidateService.ValidateRegister(UserToReg))//Validate input
            throw new Exception("Invalid credentials!");
        
        BCrypt.Net.BCrypt.EnhancedHashPassword(UserToReg.Password,12);
        
        using var context = new ContextMovie();
        context.Users.Add(UserToReg);
        context.SaveChanges();
        Console.WriteLine("Registered User!");
    }
}