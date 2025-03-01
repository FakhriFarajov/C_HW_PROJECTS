namespace ConsoleApp2;

public class Owner
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CarId { get; set; }


    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, CarId: {CarId}";
    }
}
