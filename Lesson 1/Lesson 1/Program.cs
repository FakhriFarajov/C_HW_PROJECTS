// //Task1
//
// int number;
// while (true)
// {
//     Console.Write("Type a number in 1-100 range: ");
//     number = int.Parse(Console.ReadLine());
//     if (number < 1 || number > 100)
//     {
//         Console.WriteLine("Please enter a number between 1 and 100!");
//     }
//     else
//     {
//         break;
//     }
// }
//
//
// if (number % 3 == 0 && number % 5 == 0)
// {
//     Console.WriteLine("Fizz Buzz");
// }
// else if (number % 3 == 0)
// {
//     Console.WriteLine("Fizz");
// }
// else if (number % 5 == 0)
// {
//     Console.WriteLine("Buzz");
// }
// else
// {
//     Console.WriteLine(number);
// }
//
//
//
// //Task2
//
// int number1,percent;
//
// Console.Write("Enter a number: ");
// number1 = int.Parse(Console.ReadLine());
// Console.Write("Enter a percent: ");
// percent = int.Parse(Console.ReadLine());
//
// double result = number1 * (double)percent / 100; 
//
// Console.WriteLine($"The {percent}% of {number1} is {result}");
//
//
// //Task3
// //First version
// int num1, num2, num3, num4;
// Console.Write("Enter number1: ");
// num1 = int.Parse(Console.ReadLine());
// Console.Write("Enter number2: ");
// num2 = int.Parse(Console.ReadLine());
// Console.Write("Enter number3: ");
// num3 = int.Parse(Console.ReadLine());
// Console.Write("Enter number4: ");
// num4 = int.Parse(Console.ReadLine());
//
//
// Console.WriteLine($"{num1}{num2}{num3}{num4}");
//
//
// //Second version
// string string1 = "";
// int new_integer;
// Console.Write("Enter number1: ");
// string1 += Console.ReadLine();
// Console.Write("Enter number2: ");
// string1 += Console.ReadLine();
// Console.Write("Enter number3: ");
// string1 += Console.ReadLine();
// Console.Write("Enter number4: ");
// string1 += Console.ReadLine();
// new_integer = int.Parse(string1);
//
// Console.WriteLine($"The result is {new_integer}");
//
//
//
//
// //Task4
// string string_task4;
// int first_number, second_number;
//
//
//
// while (true)
// {
//     Console.Write("Enter number: ");
//     string_task4 = Console.ReadLine();
//     if (string_task4.Length != 6)
//     {
//         Console.WriteLine("6 characters are invalid!");
//     }
//     else break;
// }
//
//
// Console.WriteLine($"Here is your number: {string_task4}");
//
//
//
//
// while (true)
// {
//     Console.Write("Enter first number: ");
//     first_number = int.Parse(Console.ReadLine());
//     Console.Write("Enter second number: ");
//     second_number = int.Parse(Console.ReadLine());
//     if (first_number < 1 || first_number > string_task4.Length || second_number < 1 || second_number > string_task4.Length || first_number == second_number)
//     {
//         Console.WriteLine("Out of range!");
//     }
//     else
//     {
//         string temp = "";
//         char first_char = string_task4[first_number-1];
//         char second_char = string_task4[second_number-1];
//         for (int i = 0; i < string_task4.Length; i++)
//         {
//             if (second_number-1 == i)
//             {
//                 
//                 temp += first_char;
//                 continue;
//             }
//             else if (first_number-1 == i)
//             {
//                 temp += second_char;
//                 continue;
//             }
//             temp += string_task4[i];
//         }
//         string_task4 = temp;
//         break;
//     }
// }
//
// Console.WriteLine($"The result is {string_task4}");



//Task5
//
// using System.Data;
//
// int day,month,year;
// string season = "";
//
//
// while (true)
// {
//     Console.Write("Enter day: ");
//     day = int.Parse(Console.ReadLine());
//     if (day < 1 || day > 31)
//     {
//         Console.WriteLine("Please enter a number between 1 and 31!");
//         continue;
//     }
//     break;
// }
//
// while (true)
// {
//     Console.Write("Enter month: ");
//     month = int.Parse(Console.ReadLine());
//     if (month < 1 || month > 12)
//     {
//         Console.WriteLine("Please enter a number between 1 and 12!");
//         continue;
//     }
//     break;
// }
//
// while (true)
// {
//     Console.Write("Enter year: ");
//     year = int.Parse(Console.ReadLine());
//
//     if (year < 1)
//     {
//         Console.WriteLine("No negative!");
//         continue;
//     }
//     break;
// }
//
// DateTime date = new DateTime(year, month, day);
//
//
// if (month == 1 || month == 2 || month == 12)
// {
//     season = "Winter";
// }
// else if (month >= 3 && month <= 5)
// {
//     season = "Spring";
// }
// else if (month >= 6 && month <= 8)
// {
//     season = "Summer";
// }
// else if (month >= 9 && month <= 11)
// {
//     season = "Autumn";
// }
//
// Console.WriteLine($"{season} {date.DayOfWeek}");
//
//
//
//
// //Task6
// float temperature_fahrenhait;
// float temperature_celsius;
// int choice;
//
// while (true)
// {
//     Console.Write("Choose the convertion:\n1)Celsius to Fahrenhait\n2)Fahrenhait to Celsius\nChoice: ");
//     choice = int.Parse(Console.ReadLine());
//     if (choice == 1)
//     {
//         Console.Write("Celsius: ");
//         temperature_celsius = float.Parse(Console.ReadLine());
//         temperature_fahrenhait = temperature_celsius * 9 / 5 + 32;
//         Console.WriteLine($"{temperature_celsius}C is {temperature_fahrenhait}F");
//         break;
//     }
//     else if(choice == 2)
//     {
//         Console.Write("Fahrenheit: ");
//         temperature_fahrenhait = float.Parse(Console.ReadLine());
//         temperature_celsius = (temperature_fahrenhait - 32) * 5 / 9;
//         Console.WriteLine($"{temperature_fahrenhait}F is {temperature_celsius}C");
//         break;
//     }
//     else
//     {
//         Console.WriteLine("Incorrect input!");
//     }
// }
//


//Task7

int start,end;


Console.Write("Enter the start: ");
start = int.Parse(Console.ReadLine());
Console.Write("Enter the end: ");
end = int.Parse(Console.ReadLine());

if (start > end)
{
    int temp = start;
    start = end;
    end = temp;
}

for (int i = start; i <= end; i++)
{
    if (i % 2 == 0) 
    { 
        Console.Write($"{i} ");
    }
}



