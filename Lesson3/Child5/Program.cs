using System.IO;

int count = 0;
string contents;
if (File.Exists(args[0].ToString()))
{
    contents = File.ReadAllText(args[0].ToString());
}
else
{
    throw new FileNotFoundException();
}

var list = contents.Split(' ');
foreach (var word in list)
{
    if (word.ToLower() == args[1].ToString().ToLower())
    {
        count++;
    }
}

Console.WriteLine($"Result{count}");
