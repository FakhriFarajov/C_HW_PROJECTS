using System.Runtime.InteropServices.JavaScript;

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
                Console.WriteLine(UsersIndex);
                break;
            }
        }
        
        while (true)
        {
            if (user.ShowRoomId == null)
            {
                if (showRoomsList.Count == 0)
                {

                    Console.WriteLine("There are no show rooms yet, wait until it will be added!");
                    return;
                }
                int counter = 0;
                foreach (var ShowRoom in showRoomsList)
                {
                    if (ShowRoom.UserCapacity <= ShowRoom.UserCount)
                    {
                        counter++;
                    }
                }

                if (counter == showRoomsList.Count)
                {
                    Console.WriteLine("All ShowRooms have reached their capacity!");
                    Console.WriteLine("Wait until there will be vacant place in any showRoom!");
                    return;
                }
                Console.WriteLine("You are a new user, please choose the ShowRoom where you want to work:");

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
                if(showRoomsList[roomId - 1].UserCapacity <= showRoomsList[roomId - 1].Users.Count)
                {
                    Console.WriteLine("There are maximum number of users in this showroom!");
                    continue;
                }
                ShowRoomIndex = roomId-1;
                user.ShowRoomId = showRoomsList[roomId - 1].Id;
                showRoomsList[roomId - 1].Users.Add(user);
                usersList[UsersIndex] = user;
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
                        ShowRoomIndex = showRoomsList.IndexOf(UserShowRoom);
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
            Console.Write("Choice: ");

            MenuChoice menuChoice = new();
            showRoomsList = fileService.GetShowRoomsFromFile(); 
            usersList = fileService.GetUsersFromFile();
            UserShowRoom = showRoomsList[ShowRoomIndex];

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

                    if (UserShowRoom.Cars.Count >= UserShowRoom.CarCapacity)
                    {
                        Console.WriteLine("There is no room for another car!");
                        continue;
                    }
                    
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
                    if (UserShowRoom.Cars.Count == 0)
                    {
                        Console.WriteLine("There are no cars yet!");
                        continue;
                    }
                    
                    Console.WriteLine("Available Car:");
                    int index3 = 0;
                    foreach (var Car in UserShowRoom.Cars)
                    {
                        index3++;
                        Console.WriteLine($"{index3}.{Car}");
                    }
                    Console.WriteLine("Choose an Car:");
                    if (!(int.TryParse(Console.ReadLine(), out int CarChoice)) || CarChoice < 1 || CarChoice > UserShowRoom.CarCount)
                    {
                        Console.WriteLine("Incorrect value!");
                        continue;
                    }
                    
                    Car CarToEdit = UserShowRoom.Cars[CarChoice-1];
                    int carIndex = UserShowRoom.Cars.IndexOf(CarToEdit);

                    Console.WriteLine("Choose the value to change:");
                    Menu CarEditMenu = new Menu();
                    CarEditMenu.MenuChoices = new()
                    {
                        new(){ Id = 1, Description = "Make" },
                        new(){ Id = 2, Description = "Model" },
                        new(){ Id = 3, Description = "IssueDate" },
                        new(){ Id = 4, Description = "Exit" },
                    };
                    
                    
                    bool flag4 = true;
                    while (flag4)
                    {
                        CarEditMenu.DisplayMenu();
                        Console.Write("Choice: ");

                        MenuChoice editMenuChoice = new();
                        
                        try
                        {
                            editMenuChoice = CarEditMenu.GetMenuChoice();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("The input is either incorrect or out of range.");
                            continue;
                        }

                        
                        switch (editMenuChoice.Id)
                        {
                            case 1:
                                Console.WriteLine($"You chose {editMenuChoice.Description}");

                                Console.WriteLine("Enter the Make of Car:");
                                string? CarMakeNew = Console.ReadLine();

                                if (CarMakeNew == "")
                                {
                                    Console.WriteLine("Invalid make name!");
                                    continue;
                                }
                                
                                CarToEdit.Make = CarMakeNew;
                                UserShowRoom.Cars[carIndex] = CarToEdit;
                                showRoomsList[ShowRoomIndex] = UserShowRoom;
                                fileService.WriteShowRoomListToFile(showRoomsList);
                                Console.WriteLine("The car was edited!");

                                break;
                            case 2:
                                Console.WriteLine($"You chose {editMenuChoice.Description}");

                                Console.WriteLine("Enter the Model of Car:");
                                string? CarModelNew = Console.ReadLine();

                                if (CarModelNew == "")
                                {
                                    Console.WriteLine("Invalid Model name!");
                                    continue;
                                }
                                
                                CarToEdit.Model = CarModelNew;
                                UserShowRoom.Cars[carIndex] = CarToEdit;
                                showRoomsList[ShowRoomIndex] = UserShowRoom;
                                fileService.WriteShowRoomListToFile(showRoomsList);
                                Console.WriteLine("The car was edited!");

                                break;
                            case 3:
                                Console.WriteLine($"You chose {editMenuChoice.Description}");
                                Console.WriteLine("Enter the IssueDate of Car:");
                                string? CarIssueDateNew = Console.ReadLine();

                                if (CarIssueDateNew == "")
                                {
                                    Console.WriteLine("Invalid IssueDate name!");
                                    continue;
                                }

                                if (!DateTime.TryParse(CarIssueDateNew, out DateTime CarIssueDate))
                                {
                                    Console.WriteLine("Invalid issue date!");
                                    continue;
                                }
                                
                                CarToEdit.Year = CarIssueDate;
                                UserShowRoom.Cars[carIndex] = CarToEdit;
                                showRoomsList[ShowRoomIndex] = UserShowRoom;
                                fileService.WriteShowRoomListToFile(showRoomsList);
                                Console.WriteLine("The car was edited!");
                                break;
                            case 4:
                                Console.WriteLine($"You chose {editMenuChoice.Description}");
                                flag4 = false;
                                break;
                            default:
                                Console.WriteLine("Incorrect input!");
                                break;
                        }
                    }
                    break;
                case 6:
                    Console.WriteLine($"You chose {menuChoice.Description}");
                    if (UserShowRoom.Cars.Count == 0)
                    {
                        Console.WriteLine("There are no cars yet!");
                        continue;
                    }
                    Console.WriteLine("Choose the Car:");
                    int index2 = 0;
                    foreach (var Car in UserShowRoom.Cars)
                    {
                        Console.WriteLine($"{++index2}.{Car}");
                    }

                    if (!(int.TryParse(Console.ReadLine(), out int UserChoice)) || UserChoice > UserShowRoom.CarCount || UserChoice < 1)
                    {
                        Console.WriteLine("Incorrect input!");
                        continue;
                    }
                    UserShowRoom.Cars.RemoveAt(index2-1);
                    showRoomsList[ShowRoomIndex] = UserShowRoom;
                    fileService.WriteShowRoomListToFile(showRoomsList);
                    Console.WriteLine("The car was removed!");
                    break;
                case 7:
                    Console.WriteLine($"You chose {menuChoice.Description}");
                    
                    break;
                case 8:
                    Console.WriteLine($"You chose {menuChoice.Description}");
                    showRoomsList[ShowRoomIndex] = UserShowRoom;
                    fileService.WriteShowRoomListToFile(showRoomsList);
                    flag = false;
                    break;
                default:
                    Console.WriteLine("You chose an invalid choice.");
                    break;
            }
        }

    }
}