namespace Project11.UsersInterfaces;

using Interfaces;
using Services;
using Classes;

public class UsualUser:IUsualUser
{
    int ShowRoomIndex = 0;
    int UsersIndex = 0;
    public void UsualUserInterface(User user)
    {
        IFileService fileService = new FileServer();
        List<ShowRoom> showRoomsList = fileService.GetShowRoomsFromFile();
        List<User> usersList = fileService.GetUsersFromFile();
        ShowRoom UserShowRoom = new ShowRoom();


        for (int i = 0; i < usersList.Count; i++)
        {
            if (usersList[i].Id == user.Id)
            {
                UsersIndex = i;
                break;
            }
        }
        
        while (true)
        {
            if (user.ShowRoomId == null)
            {
                Console.WriteLine("You are a new user, please choose the ShowRoom where you want to work:");
                if (showRoomsList.Count == 0)
                {
                    Console.WriteLine("There are no show rooms yet, wait until it will be added!");
                    return;
                }
                int index = 0;
                foreach (var showRoom in showRoomsList)
                {
                    index++;
                    Console.WriteLine($"{index}.{showRoom}");
                }

                if (!(int.TryParse(Console.ReadLine(), out int roomId)) || roomId < 1 || roomId > showRoomsList.Count())
                {
                    Console.WriteLine("Incorrect input!");
                    continue;
                }
                user.ShowRoomId = showRoomsList[roomId - 1].Id;
                showRoomsList[roomId - 1].Id = user.Id;
                showRoomsList[roomId - 1].Users.Add(user);
                ShowRoomIndex = roomId-1;
                usersList[ShowRoomIndex] = user;
                fileService.WriteUserListToFile(usersList);
                fileService.WriteShowRoomListToFile(showRoomsList);
                Console.WriteLine("You were registered in the ShowRoom!");
            }
            else
            {
                foreach (var showRoom in showRoomsList)
                {
                    if (user.ShowRoomId == showRoom.Id)
                    {
                        UserShowRoom = showRoom;
                        break;
                    }
                }
            }
            break;
        }
        
        
        
        
        Menu UserMenu = new Menu();
        UserMenu.MenuChoices = new()
        {
            new(){ Id = 1, Description = "Check Cars" },
            new(){ Id = 2, Description = "Check Statistics" },
            new(){ Id = 3, Description = "Check Users" },
            new(){ Id = 4, Description = "Add Car" },
            new(){ Id = 5, Description = "Edit Car" },
            new(){ Id = 6, Description = "Delete Car" },
            new(){ Id = 7, Description = "Sell Car" },
            new(){ Id = 8, Description = "Exit" },
        };
        
        bool flag = true;
        while (flag)
        {
            UserMenu.DisplayMenu();
            MenuChoice menuChoice = new();
            showRoomsList = fileService.GetShowRoomsFromFile(); 
            usersList = fileService.GetUsersFromFile();

            try
            {
                menuChoice = UserMenu.GetMenuChoice();
            }
            catch (Exception e)
            {
                Console.WriteLine("The input is either incorrect or out of range.");
                continue;
            }


            switch (menuChoice.Id)
            {
                case 1:
                    Console.WriteLine($"You chose {menuChoice.Description}");
                    
                    if (UserShowRoom.Cars.Count == 0)
                    {
                        Console.WriteLine("There are no cars yet!");
                        continue;
                    }

                    int index = 0;
                    foreach (var Car in UserShowRoom.Cars)
                    {
                        Console.WriteLine($"{++index}.{Car}");
                    }
                    
                    break;
                case 2:
                    Console.WriteLine($"You chose {menuChoice.Description}");
                    break;
                case 3:
                    Console.WriteLine($"You chose {menuChoice.Description}");
                    int index1 = 0;
                    foreach (var User in UserShowRoom.Users)
                    {
                        Console.WriteLine($"{++index1}.{User}");
                    }
                    break;
                    
                case 4:
                    Console.WriteLine($"You chose {menuChoice.Description}");
                    
                    Console.WriteLine("Enter the Make of Car:");
                    string CarMake = Console.ReadLine();
                    
                    Console.WriteLine("Enter the Model of Car:");
                    string CarModel = Console.ReadLine();
                    
                    Console.WriteLine("Enter a date (e.g., 2025-01-18):");
                    string userInput = Console.ReadLine();
                    DateTime userDate;

                    // Validate and parse the input
                    if (!DateTime.TryParse(userInput, out userDate))
                    {
                        Console.WriteLine("Invalid date format. Please try again.");
                        continue;
                    }
                    
                    Car car = new Car(){Make = CarMake, Model = CarModel, Year = userDate};
                    UserShowRoom.Cars.Add(car);
                    showRoomsList[ShowRoomIndex] = UserShowRoom;
                    fileService.WriteShowRoomListToFile(showRoomsList);
                    Console.WriteLine("The car was added!");
                    break;
                case 5:
                    Console.WriteLine($"You chose {menuChoice.Description}");
                    break;
                case 6:
                    Console.WriteLine($"You chose {menuChoice.Description}");
                    break;
                case 7:
                    Console.WriteLine($"You chose {menuChoice.Description}");
                    break;
                case 8:
                    Console.WriteLine($"You chose {menuChoice.Description}");
                    showRoomsList[ShowRoomIndex - 1] = UserShowRoom;
                    fileService.WriteShowRoomListToFile(showRoomsList);
                    break;
                default:
                    Console.WriteLine("You chose an invalid choice.");
                    break;
            }
        }

    }
}