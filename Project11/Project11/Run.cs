using Classes;
using Data.User_DTO;
using Interfaces;
using Project11.UsersInterfaces;
using Services;

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
            Console.Write("Choice: ");
            
            MenuChoice choice = new();
            ILoginRegisterService LogRegServer = new LoginRegisterService();
            
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

                    Console.Write("Enter Login: ");
                    var Username = Console.ReadLine();
                    if (Username == "")
                    {
                        Console.WriteLine("Incorrect value!");
                        continue;
                    }
                    
                    Console.Write("Enter Password: ");
                    var Password = Console.ReadLine();
                    if (Password == "")
                    {
                        Console.WriteLine("Incorrect value!");
                        continue;
                    }

                    Login_DTO loginDto = new Login_DTO(Username, Password);
                    
                    User MainUser  = new User(); 
                        
                    try
                    {
                        MainUser = LogRegServer.LoginUser(loginDto);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                    
                    
                    if (MainUser.UserRoleEnum == RoleEnum.USUAL)
                    {
                        IUsualUser usualUser = new UsualUser();
                        usualUser.UsualUserInterface(MainUser);
                    }
                    else
                    {
                        IAdminUser adminUser = new AdminUser();
                        adminUser.AdminUserInterface(MainUser);
                    }
                    
                    break;
                case 2:
                    Console.WriteLine($"You chose {choice.Description}");
                    Console.WriteLine("Login Entry:");
                    Console.Write(
                        "Requirements\n1.Starts with a letter.\n2.Ends with a letter or digit.\n3.Allows letters, digits, ., -, _ in between.\n4.1 to 20 characters long\nExample: [user.name].\nEnter login: ");
                    var RegisterUsername = Console.ReadLine();
                    if (RegisterUsername == "")
                    {
                        Console.WriteLine("Invalid Username!");
                        continue;
                    }
                    
                    Console.WriteLine("Password Entry:");
                    Console.Write(
                        "Requirements:\n1.At least 1 uppercase letter\n2.At least 1 lowercase letter\n3.At least 1 digit\n4.At least 1 special character (!@#$%&_)\n5.8-16 characters long\nExample: [Password123!].\nEnter password: ");
                    var RegisterPassword = Console.ReadLine();

                    if (RegisterPassword == "")
                    {
                        Console.WriteLine("Invalid Password!");
                        continue;
                    }
                    
                    Console.WriteLine("Enter the user role:");
                    Console.WriteLine("1.User\n2.Admin");
                    Console.Write("Choice: ");
                    var Role = Console.ReadLine();
                    Role = Role.ToLower();

                    int role = 0;
                    if (Role == "user") role = 1;
                    else if (Role == "admin") role = 2;
                    else
                    {
                        Console.WriteLine("Invalid role!");
                        continue;
                    }
                    
                    Register_DTO registerDto = new Register_DTO(RegisterUsername, RegisterPassword, (RoleEnum)role);
                    User MainUser1  = new User(); 
                    try
                    {
                        MainUser1 = LogRegServer.RegisterUser(registerDto);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }

                    if ((RoleEnum)role == RoleEnum.USUAL)
                    {
                        IUsualUser usualUser = new UsualUser();
                        usualUser.UsualUserInterface(MainUser1);
                    }
                    else
                    {
                        IAdminUser adminUser = new AdminUser();
                        adminUser.AdminUserInterface(MainUser1);
                    }
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