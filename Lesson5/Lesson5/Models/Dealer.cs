namespace Lesson5.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


public class Dealer
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }

    // Navigation Property
    public ICollection<Car> Cars { get; set; }
}
