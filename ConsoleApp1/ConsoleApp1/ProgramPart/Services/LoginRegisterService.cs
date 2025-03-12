namespace Project1.ProgramPart.Services;

using Project1.Data.Models;
using Project1.Data.Context;
using Project1.ProgramPart.Interfaces;

public class LoginRegisterService : ILoginRegisterService
{
    public User Login(string Login, string Password)
    {
        if (!ValidateService.ValidateLogin(Login, Password))//Validate the credentials
            throw new Exception("Invalid credentials!");
        
        using var context = new VideoGamesStore();
        var UsersList = context.Users.ToList();

        foreach (var user in UsersList)//If login and password are in list return user
        {
            if (user.Login == Login && user.Password == Password)
            {
                return user;
            }
        }
        throw new Exception("There is no such user!"); //else exception
    }


    public void Register(User UserToReg)
    {
        if (!ValidateService.ValidateRegister(UserToReg))//Validate input
            throw new Exception("Invalid credentials!");
        
        using var context = new VideoGamesStore();
        context.Users.Add(UserToReg);
        context.SaveChanges();
        Console.WriteLine("Registered User!");
    }
}