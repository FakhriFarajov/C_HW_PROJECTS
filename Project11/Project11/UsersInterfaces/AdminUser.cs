using System.Runtime.CompilerServices;
using System.Xml;
using Services;

namespace Project11.UsersInterfaces;

using Interfaces;
using Classes;

public class AdminUser:IAdminUser
{
    public void AdminUserInterface(User user)
    {
        Menu AdminMenu = new Menu();
        AdminMenu.MenuChoices = new()
        {
            new(){ Id = 1, Description = "Check users" },
            new(){ Id = 2, Description = "Check Showrooms" },
            new(){ Id = 3, Description = "Add showroom" },
            new(){ Id = 4, Description = "Edit showroom" },
            new(){ Id = 5, Description = "Delete showroom" },
            new(){ Id = 6, Description = "Exit" },
        };

        IFileService fileService = new FileServer();
        List<ShowRoom> showRoomsList = new();
        List<User> usersList = new();
        
        
        bool flag = true;
        while (flag)
        {
            AdminMenu.DisplayMenu();
            Console.Write("Choice: ");

            MenuChoice menuChoice = new();
            showRoomsList = fileService.GetShowRoomsFromFile();//Error needs to be fixed 
            usersList = fileService.GetUsersFromFile();

            try
            {
                menuChoice = AdminMenu.GetMenuChoice();
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
                    if (usersList.Count == 0)
                    {
                        Console.WriteLine("There are no users yet!");
                        continue;
                    }
                    foreach (var User in usersList)
                    {
                        if (User.UserRoleEnum == RoleEnum.ADMIN)
                        {
                            continue;
                        }
                        Console.WriteLine(User);
                    }
                    break;
                case 2:
                    Console.WriteLine($"You chose {menuChoice.Description}");
                    if (showRoomsList.Count == 0)
                    {
                        Console.WriteLine("There are no ShowRooms yet!");
                        continue;
                    }

                    int index = 0;
                    foreach (var showRoom in showRoomsList)
                    {
                        index++;
                        Console.WriteLine($"{index}.{showRoom}");
                    }
                    break;
                case 3:
                    Console.WriteLine($"You chose {menuChoice.Description}");
                    
                    Console.WriteLine("Enter the Name of ShowRoom:");
                    string showRoomName = Console.ReadLine();
                    
                    Console.WriteLine("Enter the Car capacity of ShowRoom:");
                    if (!(int.TryParse(Console.ReadLine(), out int CarCapacity)) || CarCapacity < 1)
                    {
                        Console.WriteLine("You entered an incorrect value!");
                        continue;
                    }
                    
                    Console.WriteLine("Enter the User capacity of ShowRoom:");
                    if (!(int.TryParse(Console.ReadLine(), out int userCapacity)) || userCapacity < 1)
                    {
                        Console.WriteLine("You entered an incorrect value!");
                        continue;
                    }
                    ShowRoom newShowroom = new ShowRoom(){Name = showRoomName, UserCapacity = userCapacity, CarCapacity = CarCapacity};
                    showRoomsList.Add(newShowroom);
                    Console.WriteLine("Show room was successfully created!");
                    fileService.WriteShowRoomListToFile(showRoomsList);
                    break;
                case 4:
                    Console.WriteLine($"You chose {menuChoice.Description}");
                    if (showRoomsList.Count == 0)
                    {
                        Console.WriteLine("There are no ShowRooms yet!");
                        continue;
                    }
                    Console.WriteLine("Available ShowRooms:");
                    int index1 = 0;
                    foreach (var showRoom in showRoomsList)
                    {
                        index1++;
                        Console.WriteLine($"{index1}.{showRoom}");
                    }
                    Console.WriteLine("Choose an ShowRoom:");
                    if (!(int.TryParse(Console.ReadLine(), out int showRoomChoice)) || showRoomChoice < 1 || showRoomChoice > showRoomsList.Count)
                    {
                        Console.WriteLine("Incorrect value!");
                        continue;
                    }
                    
                    ShowRoom ShowRoomToEdit = showRoomsList[showRoomChoice-1];
                    
                    Menu ShowRoomEditMenu = new Menu();
                    ShowRoomEditMenu.MenuChoices = new()
                    {
                        new(){ Id = 1, Description = "Name" },
                        new(){ Id = 2, Description = "Car Capacity" },
                        new(){ Id = 3, Description = "User Capacity" },
                        new(){ Id = 4, Description = "Exit" },
                    };
                    


                    bool flag2 = true;
                    while (flag2)
                    {
                        ShowRoomEditMenu.DisplayMenu();
                        Console.Write("Choice: ");

                        MenuChoice editMenuChoice = new();
                        try
                        {
                            editMenuChoice = ShowRoomEditMenu.GetMenuChoice();
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
                                Console.WriteLine("Enter new name:");
                                string? newName = Console.ReadLine();
                                if (newName == ShowRoomToEdit.Name || newName == "")
                                {
                                    Console.WriteLine("You entered an incorrect value!");
                                    continue;
                                }

                                ShowRoomToEdit.Name = newName;
                                Console.WriteLine("The name was changed");
                                break;
                            case 2:
                                Console.WriteLine($"You chose {editMenuChoice.Description}");
                                Console.WriteLine("Enter new car capacity:");
                                if (!(int.TryParse(Console.ReadLine(), out int newCarCapacity)))
                                {
                                    Console.WriteLine("Incorrect value!");
                                    continue;
                                }

                                if (newCarCapacity < ShowRoomToEdit.CarCount)
                                {
                                    Console.WriteLine("The capacity is too little!");
                                    continue;
                                }

                                ShowRoomToEdit.CarCapacity = newCarCapacity;
                                Console.WriteLine("The CarCapacity was changed");
                                break;
                            case 3:
                                Console.WriteLine($"You chose {editMenuChoice.Description}");
                                Console.WriteLine("Enter new user capacity:");
                                if (!(int.TryParse(Console.ReadLine(), out int newUserCapacity)))
                                {
                                    Console.WriteLine("Incorrect value!");
                                    continue;
                                }

                                if (newUserCapacity < ShowRoomToEdit.UserCount)
                                {
                                    Console.WriteLine(
                                        "The capacity is too little or the user count exceeds the value!");
                                    continue;
                                }

                                ShowRoomToEdit.UserCapacity = newUserCapacity;
                                Console.WriteLine("The UserCapacity was changed");
                                break;
                            case 4:
                                Console.WriteLine($"You chose {editMenuChoice.Description}");
                                fileService.WriteShowRoomListToFile(showRoomsList);
                                flag2 = false;
                                break;
                            default:
                                Console.WriteLine("Invalid choice");
                                break;
                        }
                    }

                    break;
                case 5:
                    Console.WriteLine($"You chose {menuChoice.Description}");
                    if (showRoomsList.Count == 0)
                    {
                        Console.WriteLine("There are no ShowRooms yet!");
                        continue;
                    }

                    Console.WriteLine("Available ShowRooms:");
                    int index2 = 0;
                    foreach (var showRoom in showRoomsList)
                    {
                        index2++;
                        Console.WriteLine($"{index2}.{showRoom}");
                    }
                    Console.WriteLine("Choose an ShowRoom:");
                    if (!(int.TryParse(Console.ReadLine(), out int showRoomChoice1)) || showRoomChoice1 < 1 || showRoomChoice1 > showRoomsList.Count)
                    {
                        Console.WriteLine("Incorrect value!");
                        continue;
                    }
                    showRoomsList.RemoveAt(showRoomChoice1-1);
                    Console.WriteLine("Show room was successfully deleted!");
                    fileService.WriteShowRoomListToFile(showRoomsList);
                    break;
                case 6:
                    Console.WriteLine($"You chose {menuChoice.Description}");
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            
        }
    }
}