using System;

class Child
{
    static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Error: Expected 3 arguments (number1, number2, operator)");
            return;
        }

        // Parse numbers
        if (!int.TryParse(args[0], out int num1) || !int.TryParse(args[1], out int num2))
        {
            Console.WriteLine("Error: Invalid numbers");
            return;
        }

        // Get the operator
        string operation = args[2];
        int result = 0;

        // Perform calculation
        switch (operation)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 == 0)
                {
                    Console.WriteLine("Error: Division by zero");
                    return;
                }
                result = num1 / num2;
                break;
            default:
                Console.WriteLine("Error: Invalid operator");
                return;
        }
        
        Console.WriteLine($"Arguments: {num1} {operation} {num2}");
        Console.WriteLine($"Result : {result}");
    }
}