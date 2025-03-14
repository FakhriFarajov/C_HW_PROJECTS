namespace Project1.Data.Models;


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Order
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int UserId { get; set; }
    public User User { get; set; }
    
    [Required]
    public DateTime Date { get; set; } = DateTime.Now;
    
    [Required]
    public decimal TotalAmount { get; set; }

    public ICollection<OrderProp> OrderProp { get; set; } = new List<OrderProp>();
    
    public override string ToString()
    {
        return $"UserId: {UserId} Date: {Date} TotalAmount: {TotalAmount}";
    }
}