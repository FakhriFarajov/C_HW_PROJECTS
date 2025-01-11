namespace Lesson11.Interfaces;
using Lesson11.Implementations;
using Lesson11.Data.Model;

public interface IFileService
{
    public void Save(Results result);
    public void Delete(int id);
    
}