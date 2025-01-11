using Lesson11.Data.Model;
using Lesson11.Interfaces;
using System.Text.Json;
 
namespace Lesson11.Implementations;

public class FileService : IFileService
{
    public List<Results>? ResultsList { get; set; } = new();
    public void Save(Results result)//Read all the text, add new result, serialize
    {
        
        var json = File.ReadAllText("./Data/Search.json");
        if (json.Length != 0)
        {
            ResultsList = JsonSerializer.Deserialize<List<Results>>(json);
            ResultsList.Add(result);
        }
        else ResultsList.Add(result);
        var jsonNew = JsonSerializer.Serialize(ResultsList);
        File.WriteAllText("./Data/Search.json", jsonNew);
    }

    public void Delete(int id)
    {
        var json = File.ReadAllText("./Data/Search.json");
        ResultsList = JsonSerializer.Deserialize<List<Results>>(json);
        bool found = false;
        
        for (int i = 0; i < ResultsList.Count; i++)
        {
            if (ResultsList[i].id == id)
            {
                ResultsList.RemoveAt(i);
                found = true;
            }
        }

        if (!found)
        {
            throw new Exception("Not Found");
        }
        var jsonNew = JsonSerializer.Serialize(ResultsList);
        File.WriteAllText("./Data/Search.json", jsonNew);
        Console.WriteLine("Deleted!");
        Console.WriteLine("Saved!");
        
    }
}