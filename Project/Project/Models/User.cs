using System.ComponentModel.DataAnnotations;

namespace Project.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required]
    [MaxLength(100)]
    public string Login { get; set; }    
    
    [Required]
    [MaxLength(100)]
    public string Password { get; set; }
    
    public ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();

    
    public override string ToString()
    {
        return $"{Login} {Email}";
    }
}