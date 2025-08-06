namespace ShahAPIDataBase.Data.Models;

public class CategoryProperty
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    public string Name { get; set; } = null!; // Example: "Color", "Size", etc.
    
    public string CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}