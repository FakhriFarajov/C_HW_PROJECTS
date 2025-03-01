namespace Lesson_4.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Car
{
    [Key] public int CarId { get; set; }

    [Required] [MaxLength(50)] public string Make { get; set; }

    [Required] [MaxLength(50)] public string Model { get; set; }

    [Range(1886, 2100)] public int Year { get; set; }

    public decimal Price { get; set; }

    public List<Sale> Sales { get; set; } = new List<Sale>();

    public List<ServiceHistory> ServiceHistories { get; set; } = new List<ServiceHistory>();
}