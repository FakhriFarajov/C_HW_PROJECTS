    namespace ShahAPIDataBase.Data.Models;

    public class Category
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = null!;

        public string? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
        public ICollection<Category> Subcategories { get; set; } = new List<Category>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
        
        public ICollection<CategoryProperty> Properties { get; set; } = new List<CategoryProperty>();
        
    }