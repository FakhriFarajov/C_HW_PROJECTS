using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Lesson5.Models;

public class Car
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Make { get; set; }

    [Required]
    public string Model { get; set; }

    [Range(1900, 2100)]
    public int Year { get; set; }

    // Foreign Key
    public int DealerId { get; set; }

    // Navigation Property
    public Dealer Dealer { get; set; }
    
    
    public string Color { get; set; }
    
    public List<CarOrder> CarOrders { get; set; } = new();




    public override string ToString()
    {
        return $"{Make} {Model}";
    }
}

