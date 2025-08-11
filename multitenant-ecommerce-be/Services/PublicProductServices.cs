using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using multitenant_ecommerce_be.Data;
using multitenant_ecommerce_be.Models;
using multitenant_ecommerce_be.Services.IServices;

namespace multitenant_ecommerce_be.Services
{
    public class PublicProductServices : IPublicProductServices
    {
        private readonly MultitenantEcommerceContext _context;
        public PublicProductServices(MultitenantEcommerceContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }
        public async Task<Product?> GetProductById(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            if (product is null)
            {
                return null;
            }
            return product;
        }

        public async Task<List<Product>> GetProductBySlug(string categorySlug, string? subcategorySlug)
        {
            if (!string.IsNullOrEmpty(subcategorySlug))
            {
                var products = await _context.Products
                .Where(p => p.Category.Slug == subcategorySlug)
                .ToListAsync();
            return products;
            throw new NotImplementedException();
            }
            else
            {
                var products = await _context.Products
                .Where(p => p.Category.ParentCategory.Slug == categorySlug)
                .ToListAsync();
            return products;
            }
        }
    }
}
