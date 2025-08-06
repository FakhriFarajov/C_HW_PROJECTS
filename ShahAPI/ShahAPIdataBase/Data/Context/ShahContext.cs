using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ShahAPIDataBase.Data.Models;

namespace ShahAPIDataBase.Data.Context;

public class ShahContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Image> Images => Set<Image>();
    public DbSet<CartItem> CartItems => Set<CartItem>();
    public DbSet<Favorite> Favorites => Set<Favorite>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Review> Reviews => Set<Review>();

    public ShahContext(DbContextOptions<ShahContext> options) : base(options) { }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
