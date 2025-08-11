namespace multitenant_ecommerce_be.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int? ParentId { get; set; }        
        public List<CategoryDTO> SubCategories { get; set; } = null!;
    }
}
