public class MenuChoice
{
    public int Id { get; set; }
    public string Description { get; set; }
}

public class Menu
{
    public List<MenuChoice> MenuChoices;
    
    public void DisplayMenu()
    {
        Console.WriteLine("Please choose an option:");
        foreach (var choice in MenuChoices)
        {
            Console.WriteLine($"{choice.Id}. {choice.Description}");
        }
    }
    
    //If the cast is good so we return if not we notify our user about the input 
    public MenuChoice GetMenuChoice()
    {
        var choice = Console.ReadLine();
        return MenuChoices[int.Parse(choice) - 1];
    }
}