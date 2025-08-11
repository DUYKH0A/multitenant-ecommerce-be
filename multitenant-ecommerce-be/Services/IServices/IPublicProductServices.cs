using Microsoft.EntityFrameworkCore;
using multitenant_ecommerce_be.Data;
using multitenant_ecommerce_be.Models;

namespace multitenant_ecommerce_be.Services.IServices
{
    public interface IPublicProductServices
    {
        public Task<List<Product>> GetProducts();
        public Task<Product?> GetProductById(int productId);
        public Task<List<Product>> GetProductBySlug(string categorySlug, string? subcategorySlug);

    }
}
