namespace Services;

using Interfaces;
using Classes;
using Data.User_DTO;

public class LoginRegisterService: ILoginRegisterService 
{
    public User LoginUser(Login_DTO loginDto)
    {
        if (!ValidateService.ValidateLogin(loginDto))//Validate the credentials
            throw new Exception("Invalid credentials!");
        
        IFileService fileService = new FileServer();
        List<User> UsersList = fileService.GetUsersFromFile();

        foreach (var user in UsersList)//If login and password are in list return user
        {
            if (user.UserName == loginDto.username && user.Password == loginDto.password)
            {
                return user;
            }
        }
        throw new Exception("There is no such user!"); //else exception
    }

    public User RegisterUser(Register_DTO registerDto)
    {
        if (!ValidateService.ValidateRegister(registerDto))//Validate input
            throw new Exception("Invalid credentials!");
        
        IFileService fileService = new FileServer();
        List<User> UsersList = fileService.GetUsersFromFile();
        foreach (var user in UsersList)//Check if there is such password
        {
            if(user.Password == registerDto.password)
                throw new Exception("This password is already in use!");
        }

        User newUser = new() { UserName = registerDto.username, Password = registerDto.password };
        UsersList.Add(newUser);
        foreach (var user in UsersList)
        {
            fileService.WriteUserToFile(user);
        }
        return newUser;
    }
}