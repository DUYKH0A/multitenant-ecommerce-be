using Microsoft.EntityFrameworkCore;
using multitenant_ecommerce_be.Models;
using multitenant_ecommerce_be.Services.IServices;

namespace multitenant_ecommerce_be.Data
{
    public class MultitenantEcommerceContext : DbContext
    {
        private readonly ITenantProvider _tenantProvider;
        public MultitenantEcommerceContext(DbContextOptions<MultitenantEcommerceContext> options,ITenantProvider tenantProvider)
            : base(options)
        {
            _tenantProvider = tenantProvider;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<User> Users { get; set; } 
        public DbSet<Product> Products { get; set; }
    }
}
