namespace Lesson1;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public float Price { get; set; }

    public override string ToString()
    {
        return $"{Brand} {Model} {Year} {Price}";
    }
}
