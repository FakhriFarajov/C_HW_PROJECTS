using Classes;

namespace Interfaces;

public interface IFileService
{
    public List<User>? UsersList { get; set; }
    public List<ShowRoom>? ShowRoomList { get; set; }
    
    
    public void WriteUserToFile(User user);
    public void WriteUserListToFile(List<User> users);
    public List<User> GetUsersFromFile();
    
    public void WriteShowRoomToFile(ShowRoom ShowRoom);
    public void WriteShowRoomListToFile(List<ShowRoom> ShowRooms);
    public List<ShowRoom> GetShowRoomsFromFile();
}