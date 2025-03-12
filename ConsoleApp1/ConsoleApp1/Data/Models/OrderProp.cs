namespace Project1.Data.Models;


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderProp
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int OrderId { get; set; }
    public Order Order { get; set; }
    
    [Required]
    public int GameId { get; set; }
    public Game Game { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    
    [Required]
    public decimal TotalPrice { get; set; }
}