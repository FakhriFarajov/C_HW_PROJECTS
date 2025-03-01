using System.ComponentModel.DataAnnotations;

namespace Lesson_4.Data.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } // Имя

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } // Фамилия

    [Phone] // Валидация номера телефона
    public string Phone { get; set; }

    public List<Sale> Sales { get; set; } = new List<Sale>(); // Связь с продажами
}