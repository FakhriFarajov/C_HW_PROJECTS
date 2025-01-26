using Interfaces;
using Classes;

string dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

if (!Directory.Exists(dataFolder))
{
    Directory.CreateDirectory(dataFolder);
}

string usersFilePath = Path.Combine(dataFolder, "Users.json");
string showroomsFilePath = Path.Combine(dataFolder, "ShowRooms.json");

if (!File.Exists(usersFilePath))
{
    File.WriteAllText(usersFilePath, "");
}

if (!File.Exists(showroomsFilePath))
{
    File.WriteAllText(showroomsFilePath, "");
}


MainMenu.StartMainMenu();
