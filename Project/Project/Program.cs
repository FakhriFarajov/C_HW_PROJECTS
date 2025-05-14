using System.Xml;
using Project;
using Project.Models;
using Project.Services;



public class Program
{
    public static void Main(string[] args)
    {
        AuthService AuthService  = new AuthService();
        using var context = new ContextMovie();
        bool flag = true;
        while(true)
        {
            Console.WriteLine("==========================");
            Console.WriteLine("Welcome to the Movie System!");

            Menu LoginRegisterMenu = new Menu();
            LoginRegisterMenu.MenuChoices = new()
            {
                new() { Id = 1, Description = "Login" },
                new() { Id = 2, Description = "Register" },
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
                        user = AuthService.Login(Username, password);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                    
                    UserInterface.Run(user);
                    break; 
                case 2:
                   Console.WriteLine("==========================");
                   Console.WriteLine($"You chose {choice1.Description}");
                   Console.WriteLine("You must enter your personal data to register!");
                   
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
                   else if (!ValidateService.ValidateEmail(email))
                   {
                       Console.WriteLine("========================");
                       Console.WriteLine("Invalid email!");
                       Console.WriteLine("==========================");
                       continue;
                   }


                   bool inSystem = false;
                   foreach (var User in context.Users.ToList())
                   {
                       if (User.Email == email)
                       {
                           Console.WriteLine("The email address is already in use!");
                           inSystem = true;
                       }
                   }
                   if (inSystem) continue;
                   
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
                   
                   User newUser = new User {Email = email, Password = RegisterPassword, Login = Login};

                   bool inSystem1 = false;
                   foreach (var User in context.Users.ToList())
                   {
                       if (User.Password == RegisterPassword)
                       {
                           Console.WriteLine("The password address is already in use!");
                           inSystem1 = true;
                       }
                   }
                   if (inSystem1) continue;
                   
                   try
                   {
                       AuthService.Register(newUser);
                   }
                   catch (Exception e)
                   {
                       Console.WriteLine("Invalid credentials!");
                       continue;
                   }
                   
                   UserInterface.Run(newUser);
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

