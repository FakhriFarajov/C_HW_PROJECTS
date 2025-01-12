namespace Lesson11.Implementations;
using Lesson11.Interfaces;

public class Run
{
    public static void RunProgram()
    {
        Menu menu = new();
        IMovieService movieService = new MovieService();
        FileService fileService = new FileService();
        
        
        bool flag = true;
        while (flag)
        {
            menu.DisplayMenu();
        
            MenuChoice choice = menu.GetMenuChoice();
        
            switch (choice.Id)
            {
                case 1:
                    Console.WriteLine($"You chose {choice.Description}");
        
                    Console.WriteLine("Enter movie name:");
                    var movieName = Console.ReadLine();
                    
                    var res = movieService.SearchMovie(movieName);
        
                    Console.WriteLine(res);
        
                    foreach (var movie in res.results)
                    {
                        Console.WriteLine(movie);
                        fileService.Save(movie);
                    }
                    break;
                case 2:
                    Console.WriteLine($"You chose {choice.Description}");
                    break;
                case 3:
                    Console.WriteLine($"You chose {choice.Description}");
                    
                    break;
                case 4:
                    Console.WriteLine($"You chose {choice.Description}");
                    Console.WriteLine("Type the id:");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        try
                        {
                            fileService.Delete(id);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Not found!");
                        }
                    }
                    break;
                case 5:
                    flag = false;
                    Console.WriteLine("Exit");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        
        Console.WriteLine("Goodbye!");
    }
    
}