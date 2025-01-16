
public class Run
{
    public static void RunProgram()
    {
        Menu LoginRegisterMenu = new Menu();
        LoginRegisterMenu.MenuChoices = new()
        {
            new(){ Id = 1, Description = "Login" },
            new(){ Id = 2, Description = "Register" },
            new(){ Id = 3, Description = "Exit" },
        };
        
        bool flag = true;
        while (flag)
        {
            LoginRegisterMenu.DisplayMenu();

            MenuChoice choice = new();

            //Checking
            
            try
            {
                choice = LoginRegisterMenu.GetMenuChoice();
            }
            catch (Exception e)
            {
                Console.WriteLine("The input is either incorrect or out of range.");
                continue;
            }
        
            switch (choice.Id)
            {
                case 1:
                    Console.WriteLine($"You chose {choice.Description}");
                    Console.WriteLine("");

                    break;
                case 2:
                    Console.WriteLine($"You chose {choice.Description}");
                    
                    break;
                case 3:
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