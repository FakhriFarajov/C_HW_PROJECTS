namespace Data.User_DTO;
using Classes;

public record Register_DTO(
    string username,
    string password,
    RoleEnum role
    );