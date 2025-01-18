namespace Interfaces;

using Data.User_DTO;
using Classes;

public interface ILoginRegisterService
{
    public User LoginUser(Login_DTO loginDto);
    public User RegisterUser(Register_DTO registerDto);
}