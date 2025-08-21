namespace ShahAPIDataBase.Data.Models;

public class Favorite
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    public string BuyerId { get; set; }
    public Buyer Buyer { get; set; }

    public string ProductId { get; set; }
    public Product Product { get; set; }

    public DateTime LikedAt { get; set; }
}