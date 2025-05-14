using System.ComponentModel.DataAnnotations;

namespace Project.Models;

public class Favourite
{
    [Key]
    public int id { get; set; }
    [Required]
    [MaxLength(100)]
    public string MovieTitle { get; set; }
    [Required]
    [MaxLength(100)]
    public string releaseDate { get; set; }

    [Required]
    public int userId { get; set; }
    
    public User User { get; set; }

    public override string ToString()
    {
        return $"{MovieTitle} - {releaseDate}";
    }
}