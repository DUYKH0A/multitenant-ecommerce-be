namespace multitenant_ecommerce_be.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<User>? Users { get; set; }
        public List<Product>? Products { get; set; }


    }
}
