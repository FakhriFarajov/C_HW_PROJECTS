namespace ShahAPIDataBase.Data.Models;

public class Buyer
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    
    public string? ImageUrl { get; set; }
    
    public string? Phone { get; set; }
    
    public bool isConfirmed { get; set; } = false;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
}
