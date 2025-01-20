namespace Classes;

public class Car
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Make { get; set; }
    public string Model { get; set; }
    public DateTime Year { get; set; }
    public override string ToString()
    {
        return $"Make: {Make}, Model: {Model}, Issue Date: {Year.ToString("yyyy-MM-dd")}";
    }
}