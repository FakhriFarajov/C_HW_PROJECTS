using System.ComponentModel.DataAnnotations;

namespace Lesson_4.Data.Models;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    [MaxLength(50)]
    public string Position { get; set; } // Должность

    public List<Sale> Sales { get; set; } = new List<Sale>(); // Связь с продажами
}