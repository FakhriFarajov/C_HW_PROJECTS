namespace Project1.Data.Models;


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
    [MaxLength(100)]
    public string Login { get; set; }    
    
    [Required]
    [MaxLength(100)]
    public string Password { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required] public decimal Balance { get; set; } = 0;
    
    [Required]
    public bool isAdmin { get; set; } = false;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}