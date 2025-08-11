using System.Text.Json.Serialization;

namespace multitenant_ecommerce_be.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int? ParentId { get; set; }
        public Category? ParentCategory { get; set; }
        public List<Category> SubCategories { get; set; } = null!;
        public List<Product> Products { get; set; } = null!;
    }
}
