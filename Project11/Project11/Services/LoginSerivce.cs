namespace Services;

using Interfaces;
using Classes;
using Data.User_DTO;

public class LoginRegisterService: ILoginRegisterService 
{
    public User LoginUser(Login_DTO loginDto)
    {
        if (!ValidateService.ValidateLogin(loginDto))
            throw new Exception();
        
        IFileService fileService = new FileServer();
        List<User> UsersList = fileService.GetUsersFromFile();

        foreach (var user in UsersList)
        {
            if (user.UserName == loginDto.username && user.Password == loginDto.password)
            {
                return user;
            }
        }
        throw new Exception();
    }

    public User RegisterUser(Register_DTO registerDto)
    {
        if (!ValidateService.ValidateRegister(registerDto))
            throw new Exception();
        
        IFileService fileService = new FileServer();
        List<User> UsersList = fileService.GetUsersFromFile();
        foreach (var user in UsersList)
        {
            if(user.Password == registerDto.password)
                throw new Exception();
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