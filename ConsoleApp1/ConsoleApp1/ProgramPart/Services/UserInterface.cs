using Project1.Data.Context;
using Project1.ProgramPart.Interfaces;
using Project1.Data.Models;

namespace Project1.ProgramPart.Services;

public class UserInterface : IUserInterface
{
    public void UserInterfaceMain(User user)
    {
        var context = new VideoGamesStore();
        bool flag = true;  
        while (flag)
        {
            Console.WriteLine("==========================");
            Menu User = new Menu();
            User.MenuChoices = new()
            {
                new(){ Id = 1, Description = "Deposit" },
                new(){ Id = 2, Description = "Check Balance" },
                new(){ Id = 3, Description = "Check games" },
                new(){ Id = 4, Description = "Buy a game" },
                new(){ Id = 5, Description = "Purchase History" },
                new(){ Id = 6, Description = "Exit" },
            };

            var flag1 = true;
            while (flag1)
            {
                Console.WriteLine("Welcome to the Video Games Store!");
                User.DisplayMenu();
                MenuChoice choice1 = new();


                try
                {
                    choice1 = User.GetMenuChoice();

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
                        Console.WriteLine($"You chose : {choice1.Description}");
                        Console.WriteLine($"Your current balance: {user.Balance} ");
                        Console.Write("Enter the value: ");
                        
                        if (!int.TryParse(Console.ReadLine(), out int userBalance) || userBalance <= 0)
                        {
                            Console.WriteLine("==========================");
                            Console.WriteLine("Please enter a valid integer.");
                            continue;
                        }
                        
                        user.Balance += userBalance;
                        context.Users.Find(user.Id).Balance = userBalance;
                        context.SaveChanges();
                        Console.WriteLine("Balance updated");
                        Console.WriteLine($"Your current balance: {user.Balance} ");
                        break;
                    
                    case 2:
                        Console.WriteLine("==========================");
                        Console.WriteLine($"You chose : {choice1.Description}");
                        Console.WriteLine($"Your current balance: {context.Users.Find(user.Id).Balance} ");
                        break;
                    case 3:
                        Console.WriteLine("==========================");
                        Console.WriteLine($"You chose : {choice1.Description}");
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
                    case 4:
                        Console.WriteLine("==========================");
                        Console.WriteLine($"You chose : {choice1.Description}");
                        if (context.Games.ToList().Count() == 0)
                        {
                            Console.WriteLine("==========================");
                            Console.WriteLine("There are no games yet");
                            continue;
                        }
                        Console.WriteLine("Games: ");

                        foreach (var game in context.Games.ToList())
                        {
                            Console.WriteLine(game);
                        }

                        Console.WriteLine("Choose the game: ");

                        if (!int.TryParse(Console.ReadLine(), out int gameId) || gameId <= 0 || gameId >= context.Games.ToList().Count())
                        {
                            Console.WriteLine("==========================");
                            Console.WriteLine("Please enter a valid integer.");
                        }
                        
                        Console.WriteLine("The quantity of a purchased game: ");

                        if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0 || quantity > context.Games.ToList().Where(game => game.Id == gameId).Count())
                        {
                            Console.WriteLine("==========================");
                            Console.WriteLine("Please enter a valid integer.");
                        }
                        
                        OrderProp orderProp = new OrderProp()
                        {
                            GameId = gameId,
                            
                            
                        };
                        

                        break;
                    case 6:
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
}