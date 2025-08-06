namespace ShahAPIDataBase.Data.Models;

public class Payment
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;
    public string PaymentStatus { get; set; } = null!; // e.g. Paid, Pending
    public string? TransactionId { get; set; }
    public DateTime? PaidAt { get; set; }
}