using Project1.ProgramPart.Interfaces;
using Project1.ProgramPart.Services;
using Project1.Data.Models;
using Mono.TextTemplating;
using System.Text.RegularExpressions;
using Project1.Data.Context;

namespace Project1.ProgramPart;


public class Program
{
    public static void Main()
    {
        Menu LoginRegisterMenu = new Menu();
        LoginRegisterMenu.MenuChoices = new()
        {
            new(){ Id = 1, Description = "Login" },
            new(){ Id = 2, Description = "Register" },
            new(){ Id = 3, Description = "Exit" },
        };


        var flag = true;
        while (flag)
        {
            Console.WriteLine("Welcome to the Video Games Store!");
            LoginRegisterMenu.DisplayMenu();
            MenuChoice choice1 = new();
            ILoginRegisterService LogReg = new LoginRegisterService();
            
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
                case 1: //Underdone 
                    Console.WriteLine($"You chose: {choice1.Description}");

                    Console.Write("Enter Login: ");
                    var Username = Console.ReadLine();
                    if (Username == "")
                    {
                        Console.WriteLine("==========================");
                        Console.WriteLine("Incorrect value!");
                        continue;
                    }
                    
                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();
                    if (password == "")
                    {
                        Console.WriteLine("==========================");
                        Console.WriteLine("Incorrect value!");
                        continue;
                    }

                    User user;
                    try
                    { 
                        user = LogReg.Login(Username, password);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }


                    if (user.isAdmin == false)
                    {
                        IUserInterface usualUser = new UserInterface();
                        usualUser.UserInterfaceMain(user);
                    }
                    else
                    {
                        // IAdminUser adminUser = new AdminUser();
                        // adminUser.AdminUserInterface(user);
                    }
                    break;
                case 2:
                    Console.WriteLine("==========================");
                    Console.WriteLine($"You chose {choice1.Description}");
                    Console.WriteLine("You must enter your personal data to register!");
                    
                    Console.WriteLine("==========================");
                    Console.Write("Enter your name: ");
                    var username = Console.ReadLine();
                    if (username == "")
                    {
                        Console.WriteLine("==========================");
                        Console.WriteLine("Invalid name!");
                        Console.WriteLine("==========================");
                        continue;
                    }
                    
                    
                    Console.WriteLine("==========================");
                    Console.WriteLine("Enter your email");
                    Console.Write(
                        "Email Requirements:\n" +
                        "1. Must contain '@' and a domain.\n" +
                        "2. Must start with a letter, digit, or allowed symbols (._%+-).\n" +
                        "3. The domain should have letters, digits, and dots.\n" +
                        "4. Ends with a valid top-level domain (e.g., .com, .org).\n" +
                        "Example: user@example.com\n" +
                        "==========================\n" +
                        "Enter email: ");

                    
                    var email = Console.ReadLine();
                    if (email == "")
                    {
                        Console.WriteLine("========================");
                        Console.WriteLine("Invalid email!");
                        Console.WriteLine("==========================");
                        continue;
                    }
                    if (!ValidateService.ValidateEmail(email))
                    {
                        Console.WriteLine("========================");
                        Console.WriteLine("Invalid email!");
                        Console.WriteLine("==========================");
                        continue;
                    }
                    
                    
                    
                    Console.WriteLine("Login Entry:");
                    Console.WriteLine("==========================");
                    Console.Write(
                        "Requirements\n1.Starts with a letter.\n2.Ends with a letter or digit.\n3.Allows letters, digits, ., -, _ in between.\n4.1 to 20 characters long\nExample: [user.name].\n==========================\nEnter login: ");
                    var Login = Console.ReadLine();
                    if (Login == "")
                    {
                        Console.WriteLine("==========================");
                        Console.WriteLine("Invalid Username!");
                        continue;
                    }
                    
                    Console.WriteLine("Password Entry:");
                    Console.WriteLine("==========================");
                    Console.Write(
                        "Requirements:\n1.At least 1 uppercase letter\n2.At least 1 lowercase letter\n3.At least 1 digit\n4.At least 1 special character (!@#$%&_)\n5.8-16 characters long\nExample: [Password123!].\n==========================\nEnter password: ");
                    var RegisterPassword = Console.ReadLine();

                    if (RegisterPassword == "")
                    {
                        Console.WriteLine("==========================");
                        Console.WriteLine("Invalid Password!");
                        continue;
                    }
                    
                    Console.WriteLine("Enter the user role:");
                    Console.WriteLine("1.User\n2.Admin\nExample[Admin]\n==========================");
                    Console.Write("Choice: ");
                    var isAdmin = Console.ReadLine();
                    isAdmin = isAdmin.ToLower();

                    bool isAdminBool = false;
                    if (isAdmin == "user") isAdminBool = false;
                    else if (isAdmin == "admin") isAdminBool = true;
                    else
                    {
                        Console.WriteLine("==========================");
                        Console.WriteLine("Invalid role!");
                        Console.WriteLine("==========================");
                        continue;
                    }
                    
                    
                    User newUser = new User {Name = username, Email = email, Password = RegisterPassword, Login = Login, isAdmin = isAdminBool};
                    
                    try
                    {
                        LogReg.Register(newUser);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        continue;
                    }
                    
                    if (isAdminBool == false)
                    {
                        IUserInterface usualUser = new UserInterface();
                        usualUser.UserInterfaceMain(newUser);
                    }
                    else
                    {
                        // IAdminUser adminUser = new AdminUser();
                        // adminUser.AdminUserInterface(MainUser1);
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