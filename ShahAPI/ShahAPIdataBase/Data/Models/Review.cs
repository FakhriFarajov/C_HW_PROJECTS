namespace ShahAPIDataBase.Data.Models;

public class Review
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string BuyerId { get; set; }
    public User Buyer { get; set; } = null!;

    public string ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int Rating { get; set; } // 1 to 5
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; }
}