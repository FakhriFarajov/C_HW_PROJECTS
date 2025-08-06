namespace ShahAPIDataBase.Data.Models;

public class OrderItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public string ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}