using Project1.Data.Models;
using Project1.Data.Context;

namespace Project1.ProgramPart.Interfaces;

public interface ILoginRegisterService
{
    public User Login(string Login, string Password);
    
    public void Register(User UserToReg);
}