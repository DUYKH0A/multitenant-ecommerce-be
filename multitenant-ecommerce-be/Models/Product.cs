using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace multitenant_ecommerce_be.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Price { get; set; }
        public int TenantId { get; set; }
        [ForeignKey("TenantId")]
        [JsonIgnore]
        public Tenant Tenant { get; set; } = null!;
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [JsonIgnore]
        public Category Category { get; set; } = null!;

    }
}
