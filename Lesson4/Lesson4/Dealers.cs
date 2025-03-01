using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Dealers
{
    [Key]
    public int Id { get; set; }
   
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Location { get; set; }
    
    
    public List<Car> Cars { get; set; }
}