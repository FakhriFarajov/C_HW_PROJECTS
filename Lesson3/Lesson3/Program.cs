using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Channels;


// #region Task1
// Console.WriteLine($"Process with id: {Process.GetCurrentProcess().Id} started");
// ProcessStartInfo processStartInfo = new ProcessStartInfo()
// {
//     FileName = $"\"C:\\Users\\Hp\\Documents\\System\\Lesson3\\Child1\\bin\\Debug\\net8.0\\Child1.exe\"",
//     Arguments = "arg1 arg2 arg3",
//     RedirectStandardOutput = true,
//     UseShellExecute = false,
//     CreateNoWindow = true
// };
//
// Process process = new Process() {StartInfo = processStartInfo};
//
//
// process.EnableRaisingEvents = true;
// process.Exited += (sender, e) => Console.WriteLine($"Child process with id: {process.Id} finished");
// process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
//
// process.Start();
//
// Console.WriteLine($"Child process with id: {process.Id} started");
//
// process.BeginOutputReadLine();
//
// process.WaitForExit();
//
//
// Console.WriteLine($"Process with id: {Process.GetCurrentProcess().Id} finished");
//
//
// #endregion

// #region Task2 (Child3)
//
// Console.WriteLine($"Process with id: {Process.GetCurrentProcess().Id} started");
//
//
// ProcessStartInfo processStartInfo1 = new ProcessStartInfo()
// {
//     FileName = $"\"C:\\Users\\Hp\\Documents\\System\\Lesson3\\Child3\\bin\\Debug\\net8.0\\Child3.exe\"",
//     RedirectStandardOutput = true,
//     UseShellExecute = false,
//     CreateNoWindow = true
// };
//
// Process process1 = new Process() {StartInfo = processStartInfo1};
// process1.EnableRaisingEvents = true;
// process1.Exited += (sender, e) => Console.WriteLine($"Child process with id: {process1.Id} finished");
// process1.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
//
//
//
// Console.WriteLine("Choose:\n1)Wait\n2)Exit\nChoice:");
// if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 2)
// {
//     throw new Exception("Invalid choice");
// }
// Thread.Sleep(2000);
//
// process1.Start();
// Console.WriteLine($"Child process with id: {process1.Id} started");
// process1.BeginOutputReadLine();
//
// switch (choice)
// {
//     case 1:
//         process1.WaitForExit();
//         break;
//     case 2:
//         process1.Kill();
//         Console.WriteLine("Task 2 finished");
//         break;
// }
// #endregion

#region Task3 (Child4)

Console.WriteLine($"Process with id: {Process.GetCurrentProcess().Id} started");

Console.Write("Enter first number: ");
string num1 = Console.ReadLine();

Console.Write("Enter second number: ");
string num2 = Console.ReadLine();

Console.Write("Enter operator (+, -, *, /): ");
string operation = Console.ReadLine();

// Create the process
ProcessStartInfo processInfo = new ProcessStartInfo()
{
    FileName = "\"C:\\Users\\Hp\\Documents\\System\\Lesson3\\Child4\\bin\\Debug\\net8.0\\Child4.exe\"",
    Arguments = $"{num1} {num2} {operation}",
    RedirectStandardOutput = true,
    UseShellExecute = false,
    CreateNoWindow = true
};

Process process = new Process() { StartInfo = processInfo };
process.Start();

// Read output from child process
string output = process.StandardOutput.ReadToEnd();
process.WaitForExit();

// Display output
Console.WriteLine("Child Process Output:");
Console.WriteLine(output);


#endregion

#region Task4 (Child5)
Console.WriteLine($"Process with id: {Process.GetCurrentProcess().Id} started");

Console.Write("Enter the path: ");
string path = Console.ReadLine();
Console.Write("Enter the word: ");
string word = Console.ReadLine();


ProcessStartInfo processInfo2 = new ProcessStartInfo()
{
    FileName = "\"C:\\Users\\Hp\\Documents\\System\\Lesson3\\Child5\\bin\\Debug\\net8.0\\Child5.exe\"",
    Arguments = $"{path} {word}",
    RedirectStandardOutput = true,
    UseShellExecute = false,
    CreateNoWindow = true
};

Process process2 = new Process() { StartInfo = processInfo2 };
process2.Start();

string output2 = process2.StandardOutput.ReadToEnd();
process2.WaitForExit();

Console.WriteLine("Child Process Output:");
Console.WriteLine(output2);

#endregion
