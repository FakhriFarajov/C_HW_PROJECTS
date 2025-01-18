using Classes;

namespace Interfaces;

public interface IFileService
{
    public List<User>? UsersList { get; set; }
    public List<ShowRoom>? ShowRoomList { get; set; }
    
    
    public void WriteUserToFile(User user);
    public List<User> GetUsersFromFile();
    
    public void WriteShowRoomToFile(ShowRoom ShowRoom);
    public List<ShowRoom> GetShowRoomsFromFile();
}