namespace ShahAPIDataBase.Data.Models;

public class ProductPropertiesValue
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public string CategoryPropertyId { get; set; }
    public CategoryProperty CategoryProperty { get; set; } = null!;

    public string Value { get; set; } = null!;
}