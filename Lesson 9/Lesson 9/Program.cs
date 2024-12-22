using System.Threading.Channels;

interface ICalculatorOperation
{
    public double Execute(double a, double b);
    public string Name { get; set; }
}
public class Addition : ICalculatorOperation
{
    public double Execute(double a, double b)
    {
        return a + b;
    }
    private string _name = "Addition";

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
}
public class Subtraction : ICalculatorOperation
{
    public double Execute(double a, double b)
    {
        return a - b;
    }
    private string _name = "Subtraction";

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
}
public class Multiplication : ICalculatorOperation{
    public double Execute(double a, double b)
    {
        return a * b;
    }
    private string _name = "Multiplication";

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
}
public class Division : ICalculatorOperation{
    public double Execute(double a, double b)
    {
        return a / b;
    }
    private string _name = "Division";

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
}

public class Program
{
    static void Main()
    {
        string exception_list_log = "";
        string file_path = "Exceptions.txt";

        if (!File.Exists(file_path))
        {
            File.Create(file_path).Close();
        }
        List <ICalculatorOperation> operations = new List<ICalculatorOperation>()
        {
            new Addition(),
            new Subtraction(),
            new Multiplication(),
            new Division()
        };
        bool is_running = true;
        while (is_running)
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
                            exception_list_log += $"FormatException: {ex.Message}|";
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
                            exception_list_log += $"FormatException: {ex.Message}|";
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
                            exception_list_log += $"FormatException: {ex.Message}|";
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
                            exception_list_log += $"FormatException: {ex.Message}|";
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
                        exception_list_log += $"DivisionByZeroException: {ex.Message}|";
                        continue;
                    } 

                    Console.WriteLine($"Result {result}");
                    operations.Add(new Division());
                    break;
                case 5:
                    using (StreamWriter writer = new StreamWriter(file_path, true))
                    {
                        string[] log_list = exception_list_log.Split("|");
                        log_list.ToList().ForEach(writer.WriteLine);
                    }
                    Console.WriteLine("Bye!");
                    is_running = false;
                    break;
            }
        }
    }
}