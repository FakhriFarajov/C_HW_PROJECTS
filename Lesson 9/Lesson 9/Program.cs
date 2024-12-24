using System.Threading.Channels;
using Lesson_9.Interfaces;
using Lesson_9.Operations;

public class Program
{
    static void Main()
    {
        string exceptionListLog = "";
        string filePath = "Exceptions.txt";

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
        List <ICalculatorOperation> operations = new List<ICalculatorOperation>()
        {
            new Addition(),
            new Subtraction(),
            new Multiplication(),
            new Division()
        };
        bool isRunning = true;
        while (isRunning)
        {
            int input = -1;
            try
            {
                Console.Write("Enter operation:\n1) Addition\n2) Subtraction\n3) Multiplication\n4) Division\n5) Exit\nChoice: ");
                input = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                exceptionListLog += $"FormatException: {ex.Message}|";
                continue;
            }   
            if (input < 1 || input > 6)
            {
                Console.WriteLine("Incorrect input.");
                continue;
            }
            double a;
            double b;
            double result;
            switch (input)
            {
                case 1:
                    while(true){
                        try
                        {
                            Console.WriteLine("Enter number 1: ");
                            a = double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter number 2: ");
                            b = double.Parse(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Enter a valid number.");
                            exceptionListLog += $"FormatException: {ex.Message}|";
                            continue;
                        }
                        break;
                    }
                    result = ((Addition)operations[0]).Execute(a,b);
                    Console.WriteLine($"Result {result}");
                    break;
                case 2:
                    while(true){
                        try
                        {
                            Console.WriteLine("Enter number 1: ");
                            a = double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter number 2: ");
                            b = double.Parse(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Enter a valid number.");
                            exceptionListLog += $"FormatException: {ex.Message}|";
                            continue;
                        }
                        break;
                    }
                    result = ((Subtraction)operations[1]).Execute(a,b);
                    Console.WriteLine($"Result {result}");
                    break;
                case 3:
                    while(true){
                        try
                        {
                            Console.WriteLine("Enter number 1: ");
                            a = double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter number 2: ");
                            b = double.Parse(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Enter a valid number.");
                            exceptionListLog += $"FormatException: {ex.Message}|";
                            continue;
                        }
                        break;
                    }
                    result = ((Multiplication)operations[2]).Execute(a,b);
                    Console.WriteLine($"Result {result}");
                    break;
                case 4:
                    while(true){
                        try
                        {
                            Console.WriteLine("Enter number 1: ");
                            a = double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter number 2: ");
                            b = double.Parse(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Enter a valid number.");
                            exceptionListLog += $"FormatException: {ex.Message}|";
                            continue;
                        }
                        break;
                    }
                    try
                    {
                        result = ((Division)operations[3]).Execute(a,b);
                        if (b == 0.0)
                        {
                            throw new DivideByZeroException();
                        }
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine("Can not divide by zero.");
                        exceptionListLog += $"DivisionByZeroException: {ex.Message}|";
                        continue;
                    } 

                    Console.WriteLine($"Result {result}");
                    operations.Add(new Division());
                    break;
                case 5:
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        string[] logList = exceptionListLog.Split("|");
                        logList.ToList().ForEach(writer.WriteLine);
                    }
                    Console.WriteLine("Bye!");
                    isRunning = false;
                    break;
            }
        }
    }
}