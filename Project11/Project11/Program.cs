using Interfaces;
using Classes;

if (!File.Exists("./Data/Users.json"))
{
    File.WriteAllText("./Data/Users.json", "");
}
if (!File.Exists("./Data/ShowRooms.json"))
{
    File.WriteAllText("./Data/ShowRooms.json", "");
}

MainMenu.StartMainMenu();