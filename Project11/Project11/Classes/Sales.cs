namespace Classes;

public class Sales
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ShowRoomId { get; set; }
    public Guid CarId { get; set; }
    public Guid UserId { get; set; }
    public DateTime SaleDate { get; set; }
}