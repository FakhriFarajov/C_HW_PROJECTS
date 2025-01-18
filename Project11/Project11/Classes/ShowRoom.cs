namespace Classes;

public class ShowRoom
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public List<Car> Cars { get; set; }
    public List<User> Users { get; set; }
    public int CarCapacity { get; set; }
    public int UserCapacity { get; set; }
    public int CarCount  => Cars.Count;
    public int UserCount  => Users.Count;
    public int SalesCount { get; set; }
    
}