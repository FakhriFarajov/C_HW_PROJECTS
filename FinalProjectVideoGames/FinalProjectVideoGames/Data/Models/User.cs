namespace FinalProjectVideoGames.Data.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Balance { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}