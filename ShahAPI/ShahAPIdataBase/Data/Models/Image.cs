namespace ShahAPIDataBase.Data.Models;

public class Image
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string ImageUrl { get; set; } = null!;

    public string ProductId { get; set; }
    public Product Product { get; set; } = null!;
}