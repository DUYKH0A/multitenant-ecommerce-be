using System.ComponentModel.DataAnnotations.Schema;

namespace multitenant_ecommerce_be.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!; 
        public int? TenantId { get; set; }
        [ForeignKey("TenantId")]
        public Tenant? Tenant { get; set; } 

    }
}
