using multitenant_ecommerce_be.DTO;
using multitenant_ecommerce_be.Models;

namespace multitenant_ecommerce_be.Services.IServices
{
    public interface IVendorProductServices
    {
        public Task<List<ProductDTO>> GetProducts();
        public Task<Product?> GetProductById(int productId);
        public Task<Product> CreateProduct(Product product);
    }
}
