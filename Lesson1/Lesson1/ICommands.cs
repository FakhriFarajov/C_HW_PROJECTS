namespace Lesson1;

public interface ICommands
{
    public void Insert (Car newCar);
    public void Update(int id, float price);
    public void Delete(int id);
    public void SelectAll();
    public void Filter(string brand);
}