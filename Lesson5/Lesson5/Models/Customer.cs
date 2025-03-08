namespace Lesson5.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<CarOrder> CarOrders { get; set; } = new();
}
