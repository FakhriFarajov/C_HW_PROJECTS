namespace ShahAPIDataBase.Data.Models;

public class Seller
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string? Phone { get; set; }

    public bool IsVerified { get; set; } = false;
    public string? CompanyName { get; set; }
    public string? TaxId { get; set; }
    public string? BankAccount { get; set; }
    public string? Website { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
