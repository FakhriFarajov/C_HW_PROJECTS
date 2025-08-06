namespace ShahAPIDataBase.Data.Models;

public class UserRole
{
    
    public string UserId { get; set; }
    public User User { get; set; } = null!;

    public string  RoleId { get; set; }
    public Role Role { get; set; } = null!;
}