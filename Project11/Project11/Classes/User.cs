namespace Classes;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ShowRoomId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public RoleEnum UserRoleEnum { get; init; } = RoleEnum.USUAL;
}