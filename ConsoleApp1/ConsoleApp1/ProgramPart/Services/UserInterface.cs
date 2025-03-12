using Microsoft.EntityFrameworkCore;
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
                new(){ Id = 3, Description = "Check catalogue" },
                new(){ Id = 4, Description = "Buy a game" },
                new(){ Id = 5, Description = "Purchase History" },
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
                        Console.WriteLine("Catalogues");
                        Console.WriteLine(context.);
                }
            }
        }
    }
}