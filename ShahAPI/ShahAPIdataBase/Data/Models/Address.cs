namespace ShahAPIDataBase.Data.Models;

public class Address
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserId { get; set; }
    public User User { get; set; } = null!;

    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;
}