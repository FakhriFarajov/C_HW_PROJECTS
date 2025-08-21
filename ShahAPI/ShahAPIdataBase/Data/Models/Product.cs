namespace ShahAPIDataBase.Data.Models;

public class Product
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public string CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public string SellerId { get; set; }
    public Seller Seller { get; set; } = null!;

    public ICollection<Image> Images { get; set; } = new List<Image>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<ProductPropertiesValue> ProductPropertiesValues { get; set; } = new List<ProductPropertiesValue>();
}