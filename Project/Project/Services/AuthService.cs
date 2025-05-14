using Project.Models;
using Project.Utilities;

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
            if (user.Login == Login && PasswordHashing.VerifyHashedPassword(user.Password, Password))
            {
                return user;
            }
        }
        throw new Exception("There is no such user!");
    }


    public void Register(User UserToReg)
    {
        if (!ValidateService.ValidateRegister(UserToReg))//Validate input
            throw new Exception("Invalid credentials!");
        UserToReg.Password = PasswordHashing.HashPassword(UserToReg.Password);//Hash the password
        var context = new ContextMovie();
        context.Users.Add(UserToReg);
        context.SaveChanges();
        Console.WriteLine("Registered User!");
    }
}