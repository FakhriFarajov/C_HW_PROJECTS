namespace Project1.Data.Context;
using Project1.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class VideoGamesStore : DbContext
{
    
    public DbSet<User> Users { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProp> OrderProperties { get; set; }
    
    
    public VideoGamesStore()
    {
        Database.Migrate();
    }


    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Ensure correct path
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("Default");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Database connection string is missing!");
            }

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}