namespace Project1.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Game
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    
    [Required]
    public int PlatformId { get; set; }
    public Platform Platform { get; set; }
    
    [Required]
    public decimal Price { get; set; }

    public ICollection<OrderProp> OrderProp { get; set; } = new List<OrderProp>();
}