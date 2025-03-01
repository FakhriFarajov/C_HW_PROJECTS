using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Car
{
    [Key]
    public int Id { get; set; }
   
    [Required]
    [MaxLength(50)]
    public string Make { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Model { get; set; }
    
    [Required]
    public int Year { get; set; }
    
    [ForeignKey("DealerId")]
    public int DealerId { get; set; }
}
