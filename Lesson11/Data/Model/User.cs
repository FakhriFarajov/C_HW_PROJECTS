namespace Lesson11.Data.Model;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public override string ToString()
    {
        return $"Username {Username}, Password {Password}, DateOfBirth {DateOfBirth}";
    }
}