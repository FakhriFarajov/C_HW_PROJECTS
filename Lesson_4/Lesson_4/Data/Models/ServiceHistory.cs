using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson_4.Data.Models;

public class ServiceHistory
{
    [Key]
    public int ServiceHistoryId { get; set; }

    [Required]
    public int CarId { get; set; }

    [Required]
    public DateTime ServiceDate { get; set; } // Дата обслуживания

    [Required]
    [MaxLength(200)]
    public string Description { get; set; } // Описание работ

    [Column(TypeName = "decimal(18,2)")]
    public decimal Cost { get; set; } // Стоимость обслуживания

    [ForeignKey("CarId")]
    public Car Car { get; set; }
}