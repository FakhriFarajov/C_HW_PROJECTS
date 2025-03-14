using System.Threading.Channels;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Project1.Data.Context;
using Project1.ProgramPart.Interfaces;
using Project1.Data.Models;

namespace Project1.ProgramPart.Services;

public class AdminInterface : IAdminInterface
{
    public void AdminInterfaceMain(User user)
    {
        var context = new VideoGamesStore();
        int IndexUser;

        bool flag = true;
        while (flag)
        {
            Console.WriteLine("==========================");
            Menu UserMenu = new Menu();
            UserMenu.MenuChoices = new()
            {
                new() { Id = 1, Description = "Add game" },
                new() { Id = 2, Description = "Remove game" },
                new() { Id = 3, Description = "Edit game" },
                new() { Id = 4, Description = "Check games" },
                new() { Id = 5, Description = "Exit" },
            };

            MenuChoice choice1 = new MenuChoice();
            UserMenu.DisplayMenu();
            try
            {
                choice1 = UserMenu.GetMenuChoice();

            }
            catch (Exception e)
            {
                Console.WriteLine("The input is either incorrect or out of range.");
                continue;
            }

            switch (choice1.Id) 
            {
                case 1:
                    Console.WriteLine("==========================");
                    Console.WriteLine($"You chose {choice1.Description}");
                    Console.Write("Enter the name of the game: ");
                    string gameName = Console.ReadLine();

                    if (gameName == "")
                    {
                        Console.WriteLine("==========================");
                        Console.WriteLine("Please enter a valid name!");
                    }

                    Console.Write("Choose the Genre:\n"
                    + "1. Action\n"
                    + "2. Adventure\n"
                    + "3. Horror\n"
                    + "Choice: ");

                    if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 3)
                    {
                        Console.WriteLine("==========================");
                        Console.WriteLine("Enter a valid value!");
                        continue;
                    }
                    
                    Console.Write("Choose the Platform:\n"
                                      + "1. Xbox\n"
                                      + "2. Computer\n"
                                      + "3. Playstation\n"
                                      + "Choice: ");
                    if (!int.TryParse(Console.ReadLine(), out int choice2) || choice2 < 1 || choice2 > 3)
                    {
                        Console.WriteLine("==========================");
                        Console.WriteLine("Enter a valid value!");
                        continue;
                    }

                    float price;

                    Console.Write("Enter the price: ");
                    try
                    {
                        if (!float.TryParse(Console.ReadLine(), out price) || price < 0)
                        {
                            Console.WriteLine("==========================");
                            Console.WriteLine("Enter a valid value!");
                            continue;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The input is either incorrect or out of range.");
                        continue;
                    }


                    Game newGame = new() {Name = gameName, GenreId = choice, PlatformId = choice2, Price = price};
                    
                    context.Games.Add(newGame);
                    context.SaveChanges();
                    Console.WriteLine("==========================");
                    Console.WriteLine("Game added successfully!");
                    Console.WriteLine("==========================");
                    break;
                case 2:
                    Console.WriteLine("==========================");
                    Console.WriteLine($"You chose {choice1.Description}");
                    if (context.Games.ToList().Count() == 0)
                    {
                        Console.WriteLine("==========================");
                        Console.WriteLine("There are no games yet");
                        continue;
                    }
                    Console.WriteLine("Games:");
                    for (int i = 0; i < context.Games.ToList().Count(); i++)
                    {
                        Console.WriteLine($"- {i+1}. {context.Games.ToList()[i]}");
                    }


                    Console.Write("Choose the Game to delete:");

                    if (!int.TryParse(Console.ReadLine(), out int choice3) || choice3 < 1 ||
                        choice3 > context.Games.ToList().Count())
                    {
                        Console.WriteLine("==========================");
                        Console.WriteLine("Enter a valid value!");
                        continue;
                    }
                    
                    context.Games.Remove(context.Games.ToList()[choice3-1]);
                    context.SaveChanges();
                    Console.WriteLine("===========================");
                    Console.WriteLine("Game deleted successfully!");
                    
                    break;
                case 3:
                    Console.WriteLine("==========================");
                    Console.WriteLine($"You chose {choice1.Description}");
                    if (context.Games.ToList().Count() == 0)
                    {
                        Console.WriteLine("==========================");
                        Console.WriteLine("There are no games yet");
                        continue;
                    }
                    Console.WriteLine("Games:");
                    for (int i = 0; i < context.Games.ToList().Count(); i++)
                    {
                        Console.WriteLine($"- {i+1}. {context.Games.ToList()[i]}");
                    }

                    Console.Write("Choose the Game to edit:");

                    if (!int.TryParse(Console.ReadLine(), out int choice4) || choice4 < 1 ||
                        choice4 > context.Games.ToList().Count())
                    {
                        Console.WriteLine("==========================");
                        Console.WriteLine("Enter a valid value!");
                        continue;
                    }

                    IndexUser = choice4 - 1;
                    Game GameSelected = context.Games.ToList()[IndexUser];

                    Console.Write("Choose what to edit: \n1. Name\n2. Genre\n3. Platform\n4. Price\nChoice:  ");
                    if (!int.TryParse(Console.ReadLine(), out int choice5) || choice5 < 1 || choice5 > 4)
                    {
                        Console.WriteLine("==========================");
                        Console.WriteLine("Enter a valid value!");
                        continue;
                    }


                    switch (choice5)
                    {
                        case 1:
                            Console.Write("Enter the new name: ");
                            string newName = Console.ReadLine();
                            if (newName == "")
                            {
                                Console.WriteLine("==========================");
                                Console.WriteLine("Enter a valid value!");
                                continue;
                            }
                            GameSelected.Name = newName;
                            context.Games.ToList()[IndexUser] = GameSelected;
                            context.SaveChanges();
                            Console.WriteLine("Game edited successfully!");
                            break;
                        case 2:
                            Console.Write("Enter the genre:\n1. Action\n2. Adventure\n3. Horror\nChoice:");
                            if (!int.TryParse(Console.ReadLine(), out int choice6) || choice6 < 1 || choice6 > 3)
                            {
                                Console.WriteLine("==========================");
                                Console.WriteLine("Enter a valid value!");
                                continue;
                            }
                            
                            GameSelected.GenreId = choice6;
                            context.Games.ToList()[IndexUser] = GameSelected;
                            context.SaveChanges();
                            Console.WriteLine("Game edited successfully!");
                            break;
                        case 3:
                            Console.Write("Enter the genre:\n1. XBox\n2. Computer\n3. PlayStation\nChoice:");
                            if (!int.TryParse(Console.ReadLine(), out int choice7) || choice7 < 1 || choice7 > 3)
                            {
                                Console.WriteLine("==========================");
                                Console.WriteLine("Enter a valid value!");
                                continue;
                            }
                            
                            GameSelected.PlatformId = choice7;
                            context.Games.ToList()[IndexUser] = GameSelected;
                            context.SaveChanges();
                            Console.WriteLine("Game edited successfully!");
                            break;
                        case 4:
                            Console.Write("Enter the new price: ");
                            if (!float.TryParse(Console.ReadLine(), out float price1) || price1 < 0)
                            {
                                Console.WriteLine("==========================");
                                Console.WriteLine("Enter a valid value!");
                                continue;
                            }
                            
                            context.Games.ToList()[IndexUser].Price = price1;
                            context.SaveChanges();
                            Console.WriteLine("Game edited successfully!");
                            break;
                    }
                    break;
                case 4:
                    Console.WriteLine("==========================");
                    Console.WriteLine($"You chose {choice1.Description}");
                    if (context.Games.ToList().Count() == 0)
                    {
                        Console.WriteLine("==========================");
                        Console.WriteLine("There are no games yet");
                        continue;
                    }
                    Console.WriteLine("Games:");
                    for (int i = 0; i < context.Games.ToList().Count(); i++)
                    {
                        Console.WriteLine($"- {i+1}. {context.Games.ToList()[i]}");
                    }
                    break;
                case 5:
                    Console.WriteLine("==========================");
                    Console.WriteLine($"You chose {choice1.Description}");
                    flag = false;
                    break;
                
                 default:
                    Console.WriteLine("==========================");
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}