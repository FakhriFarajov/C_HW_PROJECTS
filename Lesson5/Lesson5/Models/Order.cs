namespace Lesson5.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Order
{
    [Key]
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public List<CarOrder> CarOrders { get; set; } = new();
}