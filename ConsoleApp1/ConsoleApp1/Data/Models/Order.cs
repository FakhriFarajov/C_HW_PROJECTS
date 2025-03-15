namespace Project1.Data.Models;

using System;
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
    public float TotalAmount { get; set; }

    // Properly defining the relationship
    public ICollection<OrderProp> OrderProps { get; set; } = new List<OrderProp>();

    public override string ToString()
    {
        return $"UserId: {UserId} Date: {Date} TotalAmount: {TotalAmount}";
    }
}