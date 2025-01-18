using System.Text.Json;

namespace Services;

using Interfaces;
using Classes;

public class FileServer: IFileService
{
    public List<User>? UsersList { get; set; } = new();
    public List<ShowRoom>? ShowRoomList { get; set; } = new();
    
    public void WriteUserToFile(User user)
    {
        var json = File.ReadAllText("./Data/Users.json");
        if (json.Length != 0)
        {
            UsersList = JsonSerializer.Deserialize<List<User>>(json);
            UsersList.Add(user);
        }
        else UsersList.Add(user);
        var jsonNew = JsonSerializer.Serialize(UsersList);
        File.WriteAllText("./Data/Users.json", jsonNew);
    }

    public List<User> GetUsersFromFile()
    {
        var json = File.ReadAllText("./Data/Users.json");
        if (json.Length == 0)
        {
            return new List<User>();
        }
        List<User> users = JsonSerializer.Deserialize<List<User>>(json);
        return users;
    }

    public void WriteShowRoomToFile(ShowRoom showRoom)
    {
        var json = File.ReadAllText("./Data/ShowRooms.json");
        if (json.Length != 0)
        {
            ShowRoomList = JsonSerializer.Deserialize<List<ShowRoom>>(json);
            ShowRoomList.Add(showRoom);
        }
        else ShowRoomList.Add(showRoom);
        var jsonNew = JsonSerializer.Serialize(ShowRoomList);
        File.WriteAllText("./Data/ShowRooms.json", jsonNew);
        
    }

    public List<ShowRoom> GetShowRoomsFromFile()
    {
        var json = File.ReadAllText("./Data/ShowRooms.json");
        List<ShowRoom> ShowRooms = JsonSerializer.Deserialize<List<ShowRoom>>(json);
        return ShowRooms;
    }
}