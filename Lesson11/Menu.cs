public class Menu
{
    public List<MenuChoice> MenuChoices = new()
    {
        new() { Id = 1, Description = "Search for a movie by name" },
        new() { Id = 2, Description = "Search for a movie by genre" },
        new() { Id = 3, Description = "Check the history" },
        new() { Id = 4, Description = "Delete the movie by id" },
        new() { Id = 5, Description = "Exit" },
    };
    
    public void DisplayMenu()
    {
        Console.WriteLine("Please choose an option:");
        foreach (var choice in MenuChoices)
        {
            Console.WriteLine($"{choice.Id}. {choice.Description}");
        }
    }
    
    public MenuChoice GetMenuChoice()
    {
        var choice = Console.ReadLine();
        return MenuChoices[int.Parse(choice) - 1];
    }
}

public class MenuChoice
{
    public  int Id { get; set; }
    public string Description { get; set; }
}