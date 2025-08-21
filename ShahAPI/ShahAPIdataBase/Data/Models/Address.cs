namespace ShahAPIDataBase.Data.Models;

public class Address
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? BuyerId { get; set; }
    public Buyer? Buyer { get; set; }
    
    public string? SellerId { get; set; }
    public Seller? Seller { get; set; }

    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;
}