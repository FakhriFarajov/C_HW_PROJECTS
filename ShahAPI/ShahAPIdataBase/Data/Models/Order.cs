namespace ShahAPIDataBase.Data.Models;

public class Order
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string BuyerId { get; set; }
    public User Buyer { get; set; } = null!;

    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = null!; // Could be enum

    public DateTime CreatedAt { get; set; }

    public string ShippingAddressId { get; set; }
    public Address ShippingAddress { get; set; } = null!;

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public Payment? Payment { get; set; }
}