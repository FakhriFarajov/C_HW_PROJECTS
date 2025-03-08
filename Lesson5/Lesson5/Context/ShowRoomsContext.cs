using Microsoft.Extensions.Logging;

namespace Lesson5.Context;

using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


public class ShowRoomsContext : DbContext
{
    
    //Logger
    private readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
    public DbSet<Car> Cars { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Dealer> Dealers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder.UseLoggerFactory(loggerFactory);
        
        var connectionString = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build()
            .GetConnectionString("Default");
        optionsBuilder.UseSqlServer(connectionString);
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarOrder>().HasKey(co => new { co.CarId, co.OrderId });
        
        modelBuilder.Entity<Car>()
            .HasIndex(c => new { c.Make, c.Model })
            .IsUnique();
    
    }
}