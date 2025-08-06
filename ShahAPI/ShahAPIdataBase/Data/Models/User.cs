namespace ShahAPIDataBase.Data.Models;

public class User
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    
    public string? ImageUrl { get; set; }
    
    public string? Phone { get; set; }
    
    public bool isConfirmed { get; set; } = false;
    

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public ICollection<Product> Products { get; set; } = new List<Product>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
}
