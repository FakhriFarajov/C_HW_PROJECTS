using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson_4.Data.Models;

public class Sale
{
    [Key]
    public int SaleId { get; set; }

    [Required]
    public int CarId { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int EmployeeId { get; set; }

    [Required]
    public DateTime SaleDate { get; set; } // Дата продажи

    [Column(TypeName = "decimal(18,2)")]
    public decimal SalePrice { get; set; } // Цена продажи

    // Внешние ключи
    [ForeignKey("CarId")]
    public Car Car { get; set; }

    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }

    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; }
}