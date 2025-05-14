using System.Xml;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Project.Models;
using Project.Services;

namespace Project;

public static class UserInterface
{
    public static void Run(User userRun)
    {
        using var context = new ContextMovie();
        var flag = true;
        while (flag)
        {
            Console.WriteLine("==========================");
            Console.WriteLine("Welcome to the Movie System!");
        
            Menu LoginRegisterMenu = new Menu();
            LoginRegisterMenu.MenuChoices = new()
            {
                new() { Id = 1, Description = "Search for a movie" },
                new() { Id = 2, Description = "Check the favourites" },
                new() { Id = 3, Description = "Exit" },
            };

            LoginRegisterMenu.DisplayMenu();
            MenuChoice choice1 = new();

            try
            {
                choice1 = LoginRegisterMenu.GetMenuChoice();
            }
            catch (Exception e)
            {
                Console.WriteLine("The input is either incorrect or out of range.");
                continue;
            }


            switch (choice1.Id)
            {
                case 1:
                    Console.WriteLine("Enter the movie name: ");
                    string movieName = Console.ReadLine();

                    if (movieName.Length == 0)
                    {
                        Console.WriteLine("Movie name is required!");
                        continue;
                    }

                    MovieSearchResult filmsList; 
                    try
                    {
                        filmsList = MovieService.SearchMovie(movieName);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        continue;
                    }
                    if (filmsList.results.ToList().Count == 0)
                    {
                        Console.WriteLine("Movie not found!");
                        continue;
                    }

                    Console.WriteLine("Movies: ");
                    int index=1;
                    foreach (var result in filmsList.results.ToList())
                    {
                        Console.WriteLine($"{index++}{result}");
                    }

                    while (true)
                    {
                        //Entry
                        Console.WriteLine("Enter the id of the movie to save to the favourites [Enter q to stop]: ");
                        
                        int id;
                        string userEntry = Console.ReadLine();
                        if (userEntry.ToLower() == "q") break;
                        if (!int.TryParse(userEntry, out id))
                        {
                            Console.WriteLine("Incorrect value. Please try again.");
                            continue;
                        }

                        if (id == 0 || id > filmsList.results.ToList().Count || id < 1)
                        {
                            Console.WriteLine("Enter the correct id of the movie");
                            continue;
                        }

                        id--;

                        var favourite = new Favourite()
                        {
                            MovieTitle = filmsList.results.ToList()[id].title,
                            releaseDate = filmsList.results.ToList()[id].release_date,
                            userId = userRun.Id,
                        };
                        try
                        {
                            FavoriteService.SaveToFavorites(favourite, userRun.Id);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Couldn't save to favourites");
                            continue;
                        }
                        Console.WriteLine("Movie added to favourites");
                    }

                    break;
                case 2:
                    Console.WriteLine("Favourites list:");
                    foreach (var fav in FavoriteService.GetFavorites().Where(x => x.userId == userRun.Id))
                    {
                        userRun.Favourites.Add(fav);
                        Console.WriteLine(fav);
                    }

                    while (true)
                    {
                        Console.WriteLine("Type Y to export or Q to quit.");
                        string input = Console.ReadLine();
                        if (input.ToLower() == "y")
                        {
                            Console.WriteLine("Wait a moment...");
                            try
                            {
                                PdfService.Pdf(userRun);
                                EmailService.SendEmail(userRun);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                continue;
                            }

                            Console.WriteLine("Success!");
                            break;
                        }
                        else if(input.ToLower() == "q")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect value. Please try again.");
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("==========================");
                    flag = false;
                    Console.WriteLine("Exit");
                    break;
                default:
                    Console.WriteLine("==========================");
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        
    }
}