using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project.Models;

namespace Project;

public class ContextMovie : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Favourite> Favourites { get; set; }
    
    public ContextMovie()
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