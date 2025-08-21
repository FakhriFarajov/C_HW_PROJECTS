namespace ShahAPIDataBase.Data.Models;

public class CartItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string BuyerId { get; set; }
    public Buyer Buyer { get; set; }

    public string ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; }
    public DateTime AddedAt { get; set; }
}